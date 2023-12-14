using System.Net;
using System.Web.Mvc;
using AirbnbUdC.Application.Contracts.Contracts.Manager;
using AirUdC.GUI.Mappers.Manager;
using AirUdC.GUI.Models.Manager;

namespace AirUdC.GUI.Controllers.Manager
{
    public class FeedbackController : Controller
    {
        private readonly IFeedbackApplication _app;
        private readonly FeedbackMapperGUI _feedbackMapper;


        public FeedbackController(IFeedbackApplication app)
        {
            _app = app;
            _feedbackMapper = new FeedbackMapperGUI();
        }
        // GET: Feedbacks
        public ActionResult Index()
        {
            var records = _app.GetAllRecords();
            var mapped = _feedbackMapper.MapListT1toT2(records);
            return View(mapped);
        }

        // GET: Feedbacks/Details/5
        public ActionResult Details(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var feedback = _app.GetRecord(id);
            FeedbackModel feedbackModel = _feedbackMapper.MapT1toT2(feedback);
            if (feedbackModel == null)
            {
                return HttpNotFound();
            }
            return View(feedbackModel);
        }

        // GET: Feedbacks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Feedbacks/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RateForOwner,CommentsForOwner,RateForCustomer,CommentsForCustomer,ReservationId")] FeedbackModel feedback)
        {
            if (ModelState.IsValid)
            {
                _app.CreateRecord(_feedbackMapper.MapT2toT1(feedback));
                return RedirectToAction("Index");
            }

            return View(feedback);
        }

        // GET: Feedbacks/Edit/5
        public ActionResult Edit(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeedbackModel feedbackModel = _feedbackMapper.MapT1toT2(_app.GetRecord(id));
            if (feedbackModel == null)
            {
                return HttpNotFound();
            }
            return View(feedbackModel);
        }

        // POST: Feedbacks/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RateForOwner,CommentsForOwner,RateForCustomer,CommentsForCustomer,ReservationId")] FeedbackModel feedback)
        {
            if (ModelState.IsValid)
            {
                _app.UpdateRecord(_feedbackMapper.MapT2toT1(feedback));
                return RedirectToAction("Index");
            }
            return View(feedback);
        }

        // GET: Feedbacks/Delete/5
        public ActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeedbackModel feedbackModel = _feedbackMapper.MapT1toT2(_app.GetRecord(id));
            if (feedbackModel == null)
            {
                return HttpNotFound();
            }
            return View(feedbackModel);
        }

        // POST: Feedbacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _app.DeleteRecord(id);
            return RedirectToAction("Index");
        }
    }
}