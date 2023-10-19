using AirbnbUdC.Repository.Contracts.DbModel.Parameters;

namespace AirbnbUdC.Repository.Contracts.DbModel.Manager
{
    public class PropertyDbModel
    {
        public long PropertyId { get; set; }
        public string PropertyAddress { get; set; }
        public CityDbModel city { get; set; }
        public PropertyOwnerDbModel PropertyOwner { get; set; }
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
