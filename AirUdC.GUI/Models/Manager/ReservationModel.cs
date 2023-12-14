using System;
using System.Collections.Generic;
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
        public DateTime EnterDate { get; set; }

        [DisplayName("Fecha de salida")]
        public DateTime OutDate { get; set; }
        public PropertyOwnerModel property { get; set; }
        public CustomerModel customer { get; set; }

    }
}