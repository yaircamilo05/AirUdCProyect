using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Utilities.Constants.MessagesConstants;

namespace AirUdC.GUI.Models.Parameters
{
    public class CountryModel
    {
        [Key]
        [DisplayName("País Id")]
        public int CountryId { get; set; }

        [DisplayName("País")]
        [Required(ErrorMessage = MessagesConstantsCountry.requiredName)]
        [StringLength(50, ErrorMessage = MessagesConstantsCountry.stringLength, MinimumLength = 4)]
        public string CountryName { get; set; }
    }
}
