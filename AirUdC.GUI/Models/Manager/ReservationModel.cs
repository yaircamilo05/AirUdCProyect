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
        [DisplayName("propiedad")]
        public PropertyModel property { get; set; }
        [DisplayName("Cliente")]
        public CustomerModel Customer { get; set; }

        public IEnumerable<CustomerModel> customers { get; set; }

        public IEnumerable<PropertyModel> properties { get; set; }

    }
}