﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Utilities.Constants.MessagesConstants;

namespace AirUdC.GUI.Models.Parameters
{
    public class CountryModel
    {
        [Key]
        [DisplayName("País")]
        public int CountryId { get; set; }

        [DisplayName("Nombre")]
        [Required(ErrorMessage = MessagesConstantsCountry.requiredName)]
        [StringLength(50, ErrorMessage = MessagesConstantsCountry.stringLength, MinimumLength = 4)]
        public string CountryName { get; set; }
    }
}
