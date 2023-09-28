using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Constants.MessagesConstants;
using Utilities.Messages;

namespace AirUdC.GUI.Models.Parameters
{
    public class CountryModel
    {
        [DisplayName("País")]
        public int CountryId { get; set; }

        [DisplayName("Nombre")]
        [Required(ErrorMessage = MessagesConstantsCountry.requiredName)]
        [StringLength(50, ErrorMessage = MessagesConstantsCountry.stringLength, MinimumLength = 4)]
        public string CountryName { get; set; }
    }
}
