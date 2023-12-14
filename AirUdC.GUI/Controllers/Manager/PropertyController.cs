using System.Net;
using System.Web.Mvc;
using AirUdC.GUI.Models.Manager;
using AirbnbUdC.Application.Contracts.Contracts.Manager;
using AirUdC.GUI.Mappers.Manager;
using AirbnbUdC.Application.Implementation.Implementation.Manager;
using AirUdC.GUI.Models.Parameters;
using AirUdC.GUI.Mappers.Parameters;
using AirbnbUdC.Application.Contracts.Contracts.Parameters;
using AirbnbUdC.Application.Implementation.Implementation.Parameters;
using AirbnbUdC.Repository.Contracts.Contrats.Parameters;
using AirbnbUdC.Repository.Implementation.Implementations.Parameters;
using System;
using AirbnbUdC.Application.Contracts.DTO.Parameters;
using AirUdC.GUI.Models.ReportModels;
using Microsoft.Reporting.WebForms;
using System.Collections.Generic;
using System.Linq;

namespace AirUdC.GUI.Controllers.Manager
{
    public class PropertyController : Controller
    {
        private readonly IPropertyApplication _app;
        private readonly IPropertyOwnerApplication _appPropertyOwner;
        private readonly ICityApplication _appCity;
        private readonly PropertyMapperGUI _propertyMapper;
        private readonly PropertyOwnerMapperGUI _propertyOwnerMapper;
        private readonly CityMapperGUI _cityMapper;
        private readonly ICityRepository _cityRepository;
        private readonly IReservationApplication _appReservation;

        // GET: Property

        public PropertyController()
        {
            _app = new PropertyImplementationApplication();
            _propertyMapper = new PropertyMapperGUI();
            _appPropertyOwner = new PropertyOwnerImplementationApplication();
            _propertyOwnerMapper = new PropertyOwnerMapperGUI();
            _cityRepository = new CityImplementationRepository();
            _appCity = new CityImplementationApplication(_cityRepository);
            _cityMapper = new CityMapperGUI();
            _appReservation = new ReservationImplementationApplication();
        }
        public ActionResult Index(string filter = "")
        {
            var records = _app.GetAllRecords(filter);
            var mapped = _propertyMapper.MapListT1toT2(records);
            return View(mapped);
        }

        // GET: Property/Details/5
        public ActionResult Details(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var property = _app.GetRecord(id);
            PropertyModel propertyModel = _propertyMapper.MapT1toT2(property);
            if (propertyModel == null)
            {
                return HttpNotFound();
            }
            return View(propertyModel);
        }

        // GET: Property/Create
        public ActionResult Create()
        {
            PropertyModel propertyModel = new PropertyModel();
            FillListForViewPropertyOwner(propertyModel);
            FillListForViewCity(propertyModel);
            return View(propertyModel);
        }

        // POST: Property/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PropertyModel propertyModel)
        {
            ModelState.Remove("PropertyOwner.PropertyOwnerName");
            ModelState.Remove("PropertyOwner.FirstName");
            ModelState.Remove("PropertyOwner.FamilyName");
            ModelState.Remove("PropertyOwner.Email");
            ModelState.Remove("PropertyOwner.Cellphone");
            ModelState.Remove("PropertyOwner.Photo");
            ModelState.Remove("city.CityName");
            ModelState.Remove("city.Country");
            
            if (ModelState.IsValid)
            {
                CityDto cityDto = _appCity.GetRecord(propertyModel.city.CityId);
                CityModel cityModel = _cityMapper.MapT1toT2(cityDto);
                propertyModel.city = cityModel;
                _app.CreateRecord(_propertyMapper.MapT2toT1(propertyModel));
                return RedirectToAction("Index");
            }

            return View(propertyModel);
        }

        private void FillListForViewPropertyOwner(PropertyModel property)
        {
            property.PropertyOwnerList = _propertyOwnerMapper.MapListT1toT2(_appPropertyOwner.GetAllRecords(string.Empty));
        }

        private void FillListForViewCity(PropertyModel property)
        {
            property.CityList = _cityMapper.MapListT1toT2(_appCity.GetAllRecords(string.Empty));
        }   

        // GET: Property/Edit/5
        public ActionResult Edit(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyModel propertyModel = _propertyMapper.MapT1toT2(_app.GetRecord(id));
            FillListForViewPropertyOwner(propertyModel);
            FillListForViewCity(propertyModel);
            if (propertyModel == null)
            {
                return HttpNotFound();
            }
            return View(propertyModel);
        }

        // POST: Property/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PropertyModel propertyModel)
        {
            ModelState.Remove("PropertyOwner.PropertyOwnerName");
            ModelState.Remove("PropertyOwner.FirstName");
            ModelState.Remove("PropertyOwner.FamilyName");
            ModelState.Remove("PropertyOwner.Email");
            ModelState.Remove("PropertyOwner.Cellphone");
            ModelState.Remove("PropertyOwner.Photo");
            ModelState.Remove("city.CityName");
            ModelState.Remove("city.Country");
            if (ModelState.IsValid)
            {
                _app.UpdateRecord(_propertyMapper.MapT2toT1(propertyModel));
                return RedirectToAction("Index");
            }
            return View(propertyModel);
        }

        // GET: Property/Delete/5
        public ActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyModel propertyModel = _propertyMapper.MapT1toT2(_app.GetRecord(id));
            if (propertyModel == null)
            {
                return HttpNotFound();
            }
            return View(propertyModel);
        }

        // POST: Property/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _app.DeleteRecord(id);
            return RedirectToAction("Index");
        }

        public ActionResult PropertiesByCitiesReport(string format = "PDF")
        {
            var records = _app.GetAllRecords(string.Empty);

            List<PropertiesByCitiesReportModel> reportModels = new List<PropertiesByCitiesReportModel>();

            foreach (var item in records)
            {
                
                reportModels.Add(new PropertiesByCitiesReportModel
                {
                   Id = item.PropertyId.ToString(),
                   CityId = item.city.CityId.ToString(),
                   CityName = item.city.CityName,
                   Count = _app.GetAllRecordsByCityId(item.city.CityId).ToList().Count.ToString()
                });
            }



            string reportPath = Server.MapPath("~/Reports/RdlcFiles/PropertiesByCitiesReport.rdlc");
            LocalReport lr = new LocalReport();

            //variables para renderizar el reporte

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;
            string mimeType, encoding, fileNameExtension;

            lr.ReportPath = reportPath;
            //debe ser el mismo nombre que el dataset del reporte .rdlc
            ReportDataSource rd = new ReportDataSource("PropertiesByCitiesDataSet", reportModels);
            lr.DataSources.Add(rd);

            renderedBytes = lr.Render(
            format,
            string.Empty,
            out mimeType,
            out encoding,
            out fileNameExtension,
            out streams,
            out warnings
            );

            return File(renderedBytes, mimeType);
        }

        public ActionResult PropertiesByOwnerReport(string format = "PDF")
        {
            var records = _app.GetAllRecords(string.Empty);

            List<PropertiesByOwnerReportModel> reportModels = new List<PropertiesByOwnerReportModel>();

            foreach (var item in records)
            {
                reportModels.Add(new PropertiesByOwnerReportModel
                {
                    Id = item.PropertyId.ToString(),
                    PropertyAddress = item.PropertyAddress,
                    CustomerAmount = item.CustomerAmount.ToString(),
                    Price = item.Price.ToString(),
                    PropertyOwnerId = item.PropertyOwner.PropertyOwnerId.ToString(),
                    PropertyOwnerFullName = item.PropertyOwner.FirstName + " " + item.PropertyOwner.FamilyName,
                    Reservations = _appReservation.GetAllRecordsByPropertyId(item.PropertyId).ToList().Count.ToString(),
                });
            }



            string reportPath = Server.MapPath("~/Reports/RdlcFiles/PropertiesByOwnerReport.rdlc");
            LocalReport lr = new LocalReport();

            //variables para renderizar el reporte

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;
            string mimeType, encoding, fileNameExtension;

            lr.ReportPath = reportPath;
            //debe ser el mismo nombre que el dataset del reporte .rdlc
            ReportDataSource rd = new ReportDataSource("PropertiesByOwnerDataSet", reportModels);
            lr.DataSources.Add(rd);

            renderedBytes = lr.Render(
            format,
            string.Empty,
            out mimeType,
            out encoding,
            out fileNameExtension,
            out streams,
            out warnings
            );

            return File(renderedBytes, mimeType);
        }
    }
}

