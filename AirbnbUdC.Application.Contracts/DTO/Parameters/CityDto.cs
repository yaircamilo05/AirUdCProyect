namespace AirbnbUdC.Application.Contracts.DTO.Parameters
{
    public class CityDto
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public CountryDto Country { get; set; }
    }
}
