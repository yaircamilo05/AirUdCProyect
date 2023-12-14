using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirUdC.GUI.Models.ReportModels
{
    public class FeedbackByPropertyReportModel
    {
        public string Id { get; set; }
        public string ReservationId { get; set; }
        public string PropertyId { get; set; }
        public string RateCustomer { get; set; }
        public string PropertyAdress { get; set; }
    }
}