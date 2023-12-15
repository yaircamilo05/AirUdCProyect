using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using AirbnbUdC.Application.Contracts.Contracts.Manager;
using AirUdC.GUI.Mappers.Manager;
using AirUdC.GUI.Models.Manager;
using AirUdC.GUI.Models.ReportModels;
using Microsoft.Reporting.WebForms;
using WebGrease;

namespace AirUdC.GUI.Controllers.Manager
{
    public class FeedbackController : Controller
    {
        private readonly IFeedbackApplication _app;
        private readonly FeedbackMapperGUI _feedbackMapper;
        private readonly ReservationMapperGUI _reservationMapper;
        private readonly IReservationApplication _appReservation;


        public FeedbackController(IFeedbackApplication app, IReservationApplication appReservation)
        {
            _app = app;
            _feedbackMapper = new FeedbackMapperGUI();
            _reservationMapper = new ReservationMapperGUI();
            _appReservation = appReservation;
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
            FeedbackModel model = new FeedbackModel();
            FillListForView(model);
            return View(model);
        }

        // POST: Feedbacks/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FeedbackModel feedback)
        {
            ModelState.Remove("Reservation.Price");
            ModelState.Remove("Reservation.EnterDate");
            ModelState.Remove("Reservation.OutDate");
            ModelState.Remove("Reservation.property");
            ModelState.Remove("Reservation.Customer");
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

        private void FillListForView(FeedbackModel feedbackModel)
        {
            feedbackModel.Reservations = _reservationMapper.MapListT1toT2(_appReservation.GetAllRecords());
        }

        public ActionResult FeedbackByPropertyReport(string format = "PDF")
        {
            var records = _app.GetAllRecords();

            List<FeedbackByPropertyReportModel> reportModels = new List<FeedbackByPropertyReportModel>();

            foreach (var item in records)
            {
                
                reportModels.Add(new FeedbackByPropertyReportModel
                {
                    Id = item.FeedbackId.ToString(),
                    RateCustomer = item.RateForOwner.ToString(),
                    ReservationId = item.Reservation.ReservationId.ToString(),
                    PropertyId = item.Reservation.property.PropertyId.ToString(),
                    PropertyAddress = item.Reservation.property.PropertyAddress,
                    CommentsForOwner = item.CommentsForOwner,
                    AvgRate = _app.GetAvgRateByPropertyId(item.Reservation.property.PropertyId)
                    
                });
            }

            string reportPath = Server.MapPath("~/Reports/RdlcFiles/FeedbackByPropertyReport.rdlc");
            LocalReport lr = new LocalReport();

            //variables para renderizar el reporte

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;
            string mimeType, encoding, fileNameExtension;

            lr.ReportPath = reportPath;
            //debe ser el mismo nombre que el dataset del reporte .rdlc
            ReportDataSource rd = new ReportDataSource("FeedbackByPropertyDataSet", reportModels);
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