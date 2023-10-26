using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AirUdC.GUI.Models.Manager
{
    public class CustomerModel
    {

        [Key]
        [DisplayName("Identificación del usuario")]
        public long CustomerId { get; set; }
        [DisplayName("Nombre")]
        public string FirstName { get; set; }
        [DisplayName("Apellido")]
        public string FamilyName { get; set; }
        [DisplayName("Correo")]
        public string Email { get; set; }
        [DisplayName("Celular")]
        public string Cellphone { get; set; }
        [DisplayName("Foto")]
        public string Photo { get; set; }
    }
}