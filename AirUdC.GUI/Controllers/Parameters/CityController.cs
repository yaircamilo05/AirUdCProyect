using System.Net;
using System.Web.Mvc;
using AirbnbUdC.Application.Contracts.Contracts.Parameters;
using AirbnbUdC.Application.Implementation.Implementation.Parameters;
using AirUdC.GUI.Mappers.Parameters;
using AirUdC.GUI.Models.Parameters;

namespace AirUdC.GUI.Controllers.Parameters
{
    public class CityController : Controller
    {
        private readonly ICityApplication _app;
        private readonly CityMapperGUI _cityMapper;

        public CityController()
        {
            _app = new CityImplementationApplication();
            _cityMapper = new CityMapperGUI();
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
            return View();
        }

        // POST: City/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CityId,CityName")] CityModel cityModel)
        {
            if (ModelState.IsValid)
            {
                _app.CreateRecord(_cityMapper.MapT2toT1(cityModel));
                return RedirectToAction("Index");
            }

            return View(cityModel);
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
    }
}
