using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AirUdC.GUI.Models;
using AirbnbUdC.Repository.Implementation.DataModel;

namespace AirUdC.GUI.Controllers.Manager
{
    public class PropertyMultimediaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PropertyMultimedia
        public ActionResult Index()
        {
            var propertyMultimedias = db.PropertyMultimedias.Include(p => p.MultimediaType).Include(p => p.Property);
            return View(propertyMultimedias.ToList());
        }

        // GET: PropertyMultimedia/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyMultimedia propertyMultimedia = db.PropertyMultimedias.Find(id);
            if (propertyMultimedia == null)
            {
                return HttpNotFound();
            }
            return View(propertyMultimedia);
        }

        // GET: PropertyMultimedia/Create
        public ActionResult Create()
        {
            ViewBag.MultimediaTypeId = new SelectList(db.MultimediaTypes, "Id", "MultimediaTypeName");
            ViewBag.PropertyId = new SelectList(db.Properties, "Id", "PropertyAddress");
            return View();
        }

        // POST: PropertyMultimedia/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MultimediaName,MultimediaLink,PropertyId,MultimediaTypeId")] PropertyMultimedia propertyMultimedia)
        {
            if (ModelState.IsValid)
            {
                db.PropertyMultimedias.Add(propertyMultimedia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MultimediaTypeId = new SelectList(db.MultimediaTypes, "Id", "MultimediaTypeName", propertyMultimedia.MultimediaTypeId);
            ViewBag.PropertyId = new SelectList(db.Properties, "Id", "PropertyAddress", propertyMultimedia.PropertyId);
            return View(propertyMultimedia);
        }

        // GET: PropertyMultimedia/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyMultimedia propertyMultimedia = db.PropertyMultimedias.Find(id);
            if (propertyMultimedia == null)
            {
                return HttpNotFound();
            }
            ViewBag.MultimediaTypeId = new SelectList(db.MultimediaTypes, "Id", "MultimediaTypeName", propertyMultimedia.MultimediaTypeId);
            ViewBag.PropertyId = new SelectList(db.Properties, "Id", "PropertyAddress", propertyMultimedia.PropertyId);
            return View(propertyMultimedia);
        }

        // POST: PropertyMultimedia/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MultimediaName,MultimediaLink,PropertyId,MultimediaTypeId")] PropertyMultimedia propertyMultimedia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(propertyMultimedia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MultimediaTypeId = new SelectList(db.MultimediaTypes, "Id", "MultimediaTypeName", propertyMultimedia.MultimediaTypeId);
            ViewBag.PropertyId = new SelectList(db.Properties, "Id", "PropertyAddress", propertyMultimedia.PropertyId);
            return View(propertyMultimedia);
        }

        // GET: PropertyMultimedia/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropertyMultimedia propertyMultimedia = db.PropertyMultimedias.Find(id);
            if (propertyMultimedia == null)
            {
                return HttpNotFound();
            }
            return View(propertyMultimedia);
        }

        // POST: PropertyMultimedia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            PropertyMultimedia propertyMultimedia = db.PropertyMultimedias.Find(id);
            db.PropertyMultimedias.Remove(propertyMultimedia);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
