using AirbnbUdC.Application.Contracts.DTO.Parameters;
using System.ComponentModel;

namespace AirUdC.GUI.Models.Manager
{
    public class PropertyMultimediaModel
    {
        [DisplayName("Nombre Multimedia")]
        public int? MultimediaName { get; set; }
        [DisplayName("Link Multimedia")]
        public string MultimediaLink { get; set; }

        //[DisplayName("Propiedad")]
        //public PropertyDto Property { get; set; }

        [DisplayName("Tipo Multimedia")]
        public MultimediaTypeDto MultimediaType { get; set; }
    }
}