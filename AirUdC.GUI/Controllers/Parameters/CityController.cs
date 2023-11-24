using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using AirbnbUdC.Application.Contracts.Contracts.Parameters;
using AirUdC.GUI.Mappers.Parameters;
using AirUdC.GUI.Models.Parameters;
using AirUdC.GUI.Models.ReportModels;
using Microsoft.Reporting.WebForms;

namespace AirUdC.GUI.Controllers.Parameters
{
    public class CityController : Controller
    {
        private readonly ICityApplication _app;
        private readonly ICountryApplication _countryApp;
        private readonly CityMapperGUI _cityMapper;
        private readonly CountryMapperGUI _countryMapper;

        public CityController(ICityApplication app, ICountryApplication countryApp)
        {
            _app = app;
            _cityMapper = new CityMapperGUI();
            _countryMapper = new CountryMapperGUI();
            _countryApp = countryApp;
        }
        // GET: City
        public ActionResult Index(string filter = "")
        {
            var records = _app.GetAllRecords(filter);
            var mapped = _cityMapper.MapListT1toT2(records);
            return View(mapped);
        }

        // GET: City/Details/5
        public ActionResult Details(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var city = _app.GetRecord(id);
            CityModel cityModel = _cityMapper.MapT1toT2(city);
            if (cityModel == null)
            {
                return HttpNotFound();
            }
            return View(cityModel);
        }

        // GET: City/Create
        public ActionResult Create()
        {
            CityModel cityModel = new CityModel();
            FillListForView(cityModel);
            return View(cityModel);
        }

        // POST: City/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CityModel cityModel)
        {
            ModelState.Remove("Country.CountryName");
            if (ModelState.IsValid)
            {
                _app.CreateRecord(_cityMapper.MapT2toT1(cityModel));
                return RedirectToAction("Index");
            }

            return View(cityModel);
        }

        private void FillListForView(CityModel city)
        {
            city.CountryList = _countryMapper.MapListT1toT2(_countryApp.GetAllRecords(string.Empty));
        }

        // GET: City/Edit/5
        public ActionResult Edit(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityModel cityModel = _cityMapper.MapT1toT2(_app.GetRecord(id));
            if (cityModel == null)
            {
                return HttpNotFound();
            }
            return View(cityModel);
        }

        // POST: City/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CityId,CityName")] CityModel cityModel)
        {
            if (ModelState.IsValid)
            {
                _app.UpdateRecord(_cityMapper.MapT2toT1(cityModel));
                return RedirectToAction("Index");
            }
            return View(cityModel);
        }

        // GET: City/Delete/5
        public ActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CityModel cityModel = _cityMapper.MapT1toT2(_app.GetRecord(id));
            if (cityModel == null)
            {
                return HttpNotFound();
            }
            return View(cityModel);
        }

        // POST: City/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _app.DeleteRecord(id);
            return RedirectToAction("Index");
        }

        public ActionResult CityByCountryReport(string format="PDF")
        {
            var records = _app.GetAllRecords(string.Empty);

            List<CitiesByCountryReportModel> reportModels = new List<CitiesByCountryReportModel>();

            foreach (var item in records)
            {
                reportModels.Add(new CitiesByCountryReportModel
                {
                    Id = item.CityId.ToString(),
                    Name = item.CityName,
                    CountryId = item.Country.CountryId.ToString(),
                    CountryName = item.Country.CountryName
                });
            }



            string reportPath = Server.MapPath("~/Reports/RdlcFiles/CitiesByCountryReport.rdlc");
            LocalReport lr = new LocalReport();

            //variables para renderizar el reporte

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;
            string mimeType, encoding, fileNameExtension;

            lr.ReportPath = reportPath;
            //debe ser el mismo nombre que el dataset del reporte .rdlc
            ReportDataSource rd = new ReportDataSource("CitiesByCountryDataSet", reportModels);
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
