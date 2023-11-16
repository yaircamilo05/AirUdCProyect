using System.Net;
using System.Web.Mvc;
using AirbnbUdC.Application.Contracts.Contracts.Parameters;
using AirUdC.GUI.Mappers.Parameters;
using AirUdC.GUI.Models.Parameters;

namespace AirUdC.GUI.Controllers.Parameters
{
    public class CountryController : Controller
    {
        private readonly ICountryApplication _app;
        private readonly CountryMapperGUI _countryMapper;

        public CountryController(ICountryApplication app)
        {
            _app = app;
            _countryMapper = new CountryMapperGUI();
        }
        // GET: Country
        public ActionResult Index(string filter = "")
        {
            var records = _app.GetAllRecords(filter);
            var mapped = _countryMapper.MapListT1toT2(records);
            return View(mapped);
        }

        // GET: Country/Details/5
        public ActionResult Details(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var country = _app.GetRecord(id);
            CountryModel countryModel = _countryMapper.MapT1toT2(country);
            if (countryModel == null)
            {
                return HttpNotFound();
            }
            return View(countryModel);
        }

        // GET: Country/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Country/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CountryId,CountryName")] CountryModel countryModel)
        {
            if (ModelState.IsValid)
            {
                _app.CreateRecord(_countryMapper.MapT2toT1(countryModel));
                return RedirectToAction("Index");
            }

            return View(countryModel);
        }

        // GET: Country/Edit/5
        public ActionResult Edit(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryModel countryModel =_countryMapper.MapT1toT2(_app.GetRecord(id));
            if (countryModel == null)
            {
                return HttpNotFound();
            }
            return View(countryModel);
        }

        // POST: Country/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CountryId,CountryName")] CountryModel countryModel)
        {
            if (ModelState.IsValid)
            {
                _app.UpdateRecord(_countryMapper.MapT2toT1(countryModel));
                return RedirectToAction("Index");
            }
            return View(countryModel);
        }

        // GET: Country/Delete/5
        public ActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryModel countryModel =_countryMapper.MapT1toT2(_app.GetRecord(id));
            if (countryModel == null)
            {
                return HttpNotFound();
            }
            return View(countryModel);
        }

        // POST: Country/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _app.DeleteRecord(id);
            return RedirectToAction("Index");
        }

    }
}
