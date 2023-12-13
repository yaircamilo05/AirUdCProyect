using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AirUdC.GUI.Models.Manager
{
    public class ReservationModel
    {
        [Key]
        [DisplayName("Id de la reserva")]
        public long ReservationId { get; set; }

        [DisplayName("Precio Reserva")]
        public decimal Price { get; set; }

        [DisplayName("Fecha de entrada")]
        public string EnterDate { get; set; }

        [DisplayName("Fecha de salida")]
        public string OutDate { get; set; }
        public PropertyModel property { get; set; }
        public CustomerModel customer { get; set; }
    }
}