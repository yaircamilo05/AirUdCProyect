using System.Net;
using System.Web.Mvc;
using AirbnbUdC.Application.Contracts.Contracts.Manager;
using AirUdC.GUI.Mappers.Manager;
using AirUdC.GUI.Models.Manager;

namespace AirUdC.GUI.Controllers.Manager
{
    public class ReservationController : Controller
    {

        private readonly IReservationApplication _app;
        private readonly ReservationMapperGUI _reservationMapper;

        public ReservationController(IReservationApplication app)
        {
            _app = app;
            _reservationMapper = new ReservationMapperGUI();
        }

        // GET: Reservation
        public ActionResult Index()
        {
            
            var records = _app.GetAllRecords();
            var mapped = _reservationMapper.MapListT1toT2(records);
            return View(mapped);
        }

        // GET: Reservation/Details/5
        public ActionResult Details(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var reservation = _app.GetRecord(id);
            ReservationModel reservationModel = _reservationMapper.MapT1toT2(reservation);
            if (reservationModel == null)
            {
                return HttpNotFound();
            }
            return View(reservationModel);
        }

        // GET: Reservation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reservation/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReservationModel reservationModel)
        {
            if(ModelState.IsValid)
            {
                _app.CreateRecord(_reservationMapper.MapT2toT1(reservationModel));
                return RedirectToAction("Index");
            }
            return View(reservationModel);
        }

        // GET: Reservation/Edit/5
        public ActionResult Edit(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReservationModel reservationModel = _reservationMapper.MapT1toT2(_app.GetRecord(id));
            if (reservationModel == null)
            {
                return HttpNotFound();
            }
            return View(reservationModel);
        }

        // POST: Reservation/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ReservationModel reservationModel)
        {
            if (ModelState.IsValid)
            {
              _app.UpdateRecord(_reservationMapper.MapT2toT1(reservationModel));
                return RedirectToAction("Index");
            }
            return View(reservationModel);
        }

        // GET: Reservation/Delete/5
        public ActionResult Delete(int id)
        {
            if (id<=0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReservationModel reservationModel = _reservationMapper.MapT1toT2(_app.GetRecord(id));
            if (reservationModel == null)
            {
                return HttpNotFound();
            }
            return View(reservationModel);
        }

        // POST: Reservation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _app.DeleteRecord(id);
            return RedirectToAction("Index");
        }
    }
}
