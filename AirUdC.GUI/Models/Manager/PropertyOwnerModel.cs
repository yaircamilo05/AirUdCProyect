using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AirUdC.GUI.Models.Manager
{
    public class PropertyOwnerModel
    {
        [Key]
        [Display(Name = "Id del propietario")]
        public long PropertyOwnerId { get; set; }
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