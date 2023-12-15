using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirUdC.GUI.Models.ReportModels
{
    public class PropertiesByOwnerReportModel
    {
        public string Id { get; set; }
        public string PropertyAddress { get; set; }
        public string CustomerAmount { get; set; }
        public string Price { get; set; }
        public string PropertyOwnerId { get; set; }
        public string PropertyOwnerFullName { get; set; }
        public string Reservations { get; set; }
        public string ReservationId { get; set; }
        public string TotalReservation { get; set; }
    }
}