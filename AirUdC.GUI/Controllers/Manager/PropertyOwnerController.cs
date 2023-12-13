using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AirbnbUdC.Application.Contracts.Contracts.Manager;
using AirbnbUdC.Application.Implementation.Implementation.Manager;
using AirUdC.GUI.Mappers.Manager;
using AirUdC.GUI.Models;
using AirUdC.GUI.Models.Manager;

namespace AirUdC.GUI.Controllers.Manager
{
    public class PropertyOwnerController : Controller
    {
        private readonly IPropertyOwnerApplication _app;
        private readonly PropertyOwnerMapperGUI _propertyOwnerMapper;

        public PropertyOwnerController()
        {
            _app = new PropertyOwnerImplementationApplication();
            _propertyOwnerMapper = new PropertyOwnerMapperGUI();

        }

        // GET: PropertyOwner
        public ActionResult Index(string filter="")
        {
            var records = _app.GetAllRecords(filter);
            var mapped = _propertyOwnerMapper.MapListT1toT2(records);
            return View(mapped);
        }

        // GET: PropertyOwner/Details/5
        public ActionResult Details(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var propertyOwner = _app.GetRecord(id);
             PropertyOwnerModel propertyOwnerModel = _propertyOwnerMapper.MapT1toT2(propertyOwner);
            if (propertyOwnerModel == null)
            {
                return HttpNotFound();
            }
            return View(propertyOwnerModel);
        }

        // GET: PropertyOwner/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PropertyOwner/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PropertyOwnerId,FirstName,FamilyName,Email,Cellphone,Photo")] PropertyOwnerModel propertyOwnerModel)
        {
            if (ModelState.IsValid)
            {
                _app.CreateRecord(_propertyOwnerMapper.MapT2toT1(propertyOwnerModel));
                return RedirectToAction("Index");
            }

            return View(propertyOwnerModel);
        }

        // GET: PropertyOwner/Edit/5
        public ActionResult Edit(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyOwnerModel propertyOwnerModel = _propertyOwnerMapper.MapT1toT2(_app.GetRecord(id));
            if (propertyOwnerModel == null)
            {
                return HttpNotFound();
            }
            return View(propertyOwnerModel);
        }

        // POST: PropertyOwner/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PropertyOwnerId,FirstName,FamilyName,Email,Cellphone,Photo")] PropertyOwnerModel propertyOwnerModel)
        {
            if (ModelState.IsValid)
            {
                _app.UpdateRecord(_propertyOwnerMapper.MapT2toT1(propertyOwnerModel));
                return RedirectToAction("Index");
            }
            return View(propertyOwnerModel);
        }

        // GET: PropertyOwner/Delete/5
        public ActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyOwnerModel propertyOwnerModel = _propertyOwnerMapper.MapT1toT2(_app.GetRecord(id));
            if (propertyOwnerModel == null)
            {
                return HttpNotFound();
            }
            return View(propertyOwnerModel);
        }

        // POST: PropertyOwner/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _app.DeleteRecord(id);
            return RedirectToAction("Index");
        }

    }
}
