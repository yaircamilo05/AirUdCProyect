using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AirbnbUdC.Application.Contracts.Contracts.Parameters;
using AirbnbUdC.Application.Implementation.Implementation.Parameters;
using AirUdC.GUI.Mappers.Parameters;
using AirUdC.GUI.Models.Parameters;

namespace AirUdC.GUI.Controllers.Parameters
{
    public class MultimediaTypeController : Controller
    {

        private readonly IMultimediaTypeApplication _app;
        private readonly MultimediaTypeMapperGUI _multimediaTypeMapper;
        // GET: MultimediaType

        public MultimediaTypeController(IMultimediaTypeApplication app)
        {
            _app = app;
            _multimediaTypeMapper = new MultimediaTypeMapperGUI();
        }
        public ActionResult Index(string filter="")
        {
            var records = _app.GetAllRecords(filter);
            var mapped = _multimediaTypeMapper.MapListT1toT2(records);
            return View(mapped);
        }

        // GET: MultimediaType/Details/5
        public ActionResult Details(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var multimediaType = _app.GetRecord(id);
            MultimediaTypeModel multimediaTypeModel = _multimediaTypeMapper.MapT1toT2(multimediaType);
            if (multimediaTypeModel == null)
            {
                return HttpNotFound();
            }
            return View(multimediaTypeModel);
        }

        // GET: MultimediaType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MultimediaType/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MultimediaTypeId,MultimediaTypeName")] MultimediaTypeModel multimediaTypeModel)
        {
            if (ModelState.IsValid)
            {
                _app.CreateRecord(_multimediaTypeMapper.MapT2toT1(multimediaTypeModel));
                return RedirectToAction("Index");
            }

            return View(multimediaTypeModel);
        }

        // GET: MultimediaType/Edit/5
        public ActionResult Edit(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MultimediaTypeModel multimediaTypeModel = _multimediaTypeMapper.MapT1toT2(_app.GetRecord(id));
            if (multimediaTypeModel == null)
            {
                return HttpNotFound();
            }
            return View(multimediaTypeModel);

        }

        // POST: MultimediaType/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MultimediaTypeId,MultimediaTypeName")] MultimediaTypeModel multimediaTypeModel)
        {
            if (ModelState.IsValid)
            {
                _app.UpdateRecord(_multimediaTypeMapper.MapT2toT1(multimediaTypeModel));
                return RedirectToAction("Index");
            }
            return View(multimediaTypeModel);
        }

        // GET: MultimediaType/Delete/5
        public ActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MultimediaTypeModel multimediaTypeModel = _multimediaTypeMapper.MapT1toT2(_app.GetRecord(id));
            if (multimediaTypeModel == null)
            {
                return HttpNotFound();
            }
            return View(multimediaTypeModel);
        }

        // POST: MultimediaType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _app.DeleteRecord(id);
            return RedirectToAction("Index");
        }

    }
}
