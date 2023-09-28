using AirbnbUdC.Application.Contracts.DTO.Parameters;
using System.Collections.Generic;

namespace AirbnbUdC.Application.Contracts.Contracts.Parameters
{
    public interface ICityApplication
    {
        CityDto CreateRecord(CityDto record);
        bool DeleteRecord(int recordId);
        int UpdateRecord(CityDto record);
        CityDto GetRecord(int recordId);
        IEnumerable<CityDto> GetAllRecords(string filter);
    }
}
