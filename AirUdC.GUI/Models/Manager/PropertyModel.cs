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
        [Display(Name = "Dirección")]
        public string PropertyAddress { get; set; }
        [Display(Name = "Ciudad")]
        public CityModel city { get; set; }

        [Display(Name = "Propietario")]
        public PropertyOwnerModel PropertyOwner { get; set; }

        [Display(Name = "Número Maximo de Clientes")]
        public int CustomerAmount { get; set; }

        [Display(Name = "Precio")]
        public decimal Price { get; set; }

        [Display(Name = "Latitud")]

        public string Latitude { get; set; }

        [Display(Name = "Longitud")]

        public string Longitude { get; set; }

        [Display(Name = "Informacion CheckIn")]

        public string CheckinData { get; set; }

        [Display(Name = "Informacion CheckOut")]

        public string CheckoutData { get; set; }
        public string Details { get; set; }
        public bool Pets { get; set; }
        public bool Freezer { get; set; }
        public bool LaundryService { get; set; }

        public IEnumerable<PropertyOwnerModel> PropertyOwnerList { get; set; }
        public IEnumerable<CityModel> CityList { get; set; }

        public string CompleteDirection { get; set; }
    }
}