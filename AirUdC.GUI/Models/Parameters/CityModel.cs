﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Utilities.Constants.MessagesConstants;
using System.Collections;
using System.Collections.Generic;

namespace AirUdC.GUI.Models.Parameters
{
    public class CityModel
    {
        [Key]
        [DisplayName("Ciudad")]
        public int CityId { get; set; }

        [DisplayName("Nombre")]
        [Required(ErrorMessage = MessagesConstantsCity.requiredName)]
        [StringLength(50, ErrorMessage = MessagesConstantsCity.stringLength, MinimumLength = 4)]
        public string CityName { get; set; }

        [Required(ErrorMessage = MessagesConstantsCity.requiredCountry)]
        public CountryModel Country { get; set; }

        public IEnumerable<CountryModel> CountryList { get; set; }
    }
}