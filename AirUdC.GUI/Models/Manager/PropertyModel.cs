using AirUdC.GUI.Models.Parameters;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AirUdC.GUI.Models.Manager
{
    public class PropertyModel
    {
        [Key]
        [Display(Name = "Id de la propiedad")]
        public long PropertyId { get; set; }
        public string PropertyAddress { get; set; }
        public CityModel city { get; set; }
        public PropertyOwnerModel PropertyOwner { get; set; }
        public int CustomerAmount { get; set; }
        public decimal Price { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string CheckinData { get; set; }
        public string CheckoutData { get; set; }
        public string Details { get; set; }
        public bool Pets { get; set; }
        public bool Freezer { get; set; }
        public bool LaundryService { get; set; }

        public IEnumerable<PropertyOwnerModel> PropertyOwnerList { get; set; }
        public IEnumerable<CityModel> CityList { get; set; }
    }
}