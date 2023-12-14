using System.Net;
using System.Web.Mvc;
using AirUdC.GUI.Models.Manager;
using AirbnbUdC.Application.Contracts.Contracts.Manager;
using AirUdC.GUI.Mappers.Manager;
using AirbnbUdC.Application.Implementation.Implementation.Manager;
using AirUdC.GUI.Models.Parameters;
using AirUdC.GUI.Mappers.Parameters;
using AirbnbUdC.Application.Contracts.Contracts.Parameters;
using AirbnbUdC.Repository.Contracts.Contrats.Parameters;
using AirbnbUdC.Repository.Implementation.Implementations.Parameters;
using System;
using AirbnbUdC.Application.Contracts.DTO.Parameters;

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

        // GET: Property

        public PropertyController(IPropertyApplication app, ICityApplication appCity)
        {
            _app = app;
            _propertyMapper = new PropertyMapperGUI();
            _appPropertyOwner = new PropertyOwnerImplementationApplication();
            _propertyOwnerMapper = new PropertyOwnerMapperGUI();
            _cityRepository = new CityImplementationRepository();
            _appCity = appCity;
            _cityMapper = new CityMapperGUI();
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
            //aqui
            Console.WriteLine(propertyModel.city.ToString());
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
        public ActionResult Edit([Bind(Include = "PropertyId, PropertyAddress, PropertyOwner, city, PropertyAmount, Price, Latitude, Longitude, CheckinData, CheckoutData, Details, Pets, Freezer, LaundryService")] PropertyModel propertyModel)
        {
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
    }
}
