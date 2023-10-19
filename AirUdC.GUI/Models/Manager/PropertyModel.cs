using AirbnbUdC.Application.Contracts.DTO.Manager;
using AirbnbUdC.Application.Contracts.DTO.Parameters;

namespace AirUdC.GUI.Models.Manager
{
    public class PropertyModel
    {
        public long PropertyId { get; set; }
        public string PropertyAddress { get; set; }
        public CityDto city { get; set; }
        public PropertyOwnerDto PropertyOwner { get; set; }
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
    }
}