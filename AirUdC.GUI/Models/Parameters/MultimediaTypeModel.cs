using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Utilities.Constants.MessagesConstants;

namespace AirUdC.GUI.Models.Parameters
{
    public class MultimediaTypeModel
    {
        [DisplayName("Tipo de Multimedia")]
        public int MultimediaTypeId { get; set; }

        [DisplayName("Nombre")]
        [Required(ErrorMessage = MessagesConstantsMultimediaType.requiredName)]
        [StringLength(50, ErrorMessage = MessagesConstantsMultimediaType.stringLength, MinimumLength = 4)]
        public string MultimediaTypeName { get; set; }
    }
}