using System.ComponentModel;

namespace AirUdC.GUI.Models.Manager
{
    public class PropertyOwnerModel
    {
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