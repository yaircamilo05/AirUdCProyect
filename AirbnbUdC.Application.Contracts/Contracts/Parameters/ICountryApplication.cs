using AirbnbUdC.Application.Contracts.DTO.Parameters;
using System.Collections.Generic;

namespace AirbnbUdC.Application.Contracts.Contracts.Parameters
{
    public interface ICountryApplication
    {
        CountryDto CreateRecord(CountryDto record);
        bool DeleteRecord(int recordId);
        int UpdateRecord(CountryDto record);
        CountryDto GetRecord(int recordId);
        IEnumerable<CountryDto> GetAllRecords(string filter);
    }
}
