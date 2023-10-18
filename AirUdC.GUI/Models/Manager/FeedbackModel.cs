using AirbnbUdC.Application.Contracts.DTO.Parameters;
using System.ComponentModel;

namespace AirUdC.GUI.Models.Manager
{
    public class FeedbackModel
    {
        [DisplayName("Calificación Propietario")]
        public int? RateForOwner { get; set; }
        [DisplayName("Comentarios Propietario")]
        public string CommentsForOwner { get; set; }
        [DisplayName("Calificación Cliente")]
        public int? RateForCustomer { get; set; }
        [DisplayName("Comentarios Cliente")]
        public string CommentsForCustomer { get; set; }
        [DisplayName("Reserva")]
        public ReservationDto Reservation { get; set; }
    }
}