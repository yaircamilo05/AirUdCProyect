using AirbnbUdC.Application.Contracts.DTO.Manager;
using System.Collections.Generic;

namespace AirbnbUdC.Application.Contracts.Contracts.Manager
{
    public interface IPropertyApplication
    {
        PropertyDto CreateRecord(PropertyDto record);
        bool DeleteRecord(int recordId);
        PropertyDto GetRecord(int recordId);
        IEnumerable<PropertyDto> GetAllRecords(string filter);
        int UpdateRecord(PropertyDto record);
        IEnumerable<PropertyDto> GetAllRecordsByCityId(int CityId);
        IEnumerable<PropertyDto> GetAllRecordsByPropertyOwnerId(int PropertyOwnerId);

    }
}
