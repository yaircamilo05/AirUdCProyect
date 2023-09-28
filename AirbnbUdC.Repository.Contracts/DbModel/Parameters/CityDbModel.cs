namespace AirbnbUdC.Repository.Contracts.DbModel.Parameters
{
    public class CityDbModel
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public CountryDbModel Country { get; set; }
    }
}
