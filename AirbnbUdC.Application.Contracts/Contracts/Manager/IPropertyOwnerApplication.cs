using AirbnbUdC.Application.Contracts.DTO.Manager;
using System.Collections.Generic;

namespace AirbnbUdC.Application.Contracts.Contracts.Manager
{
    public interface IPropertyOwnerApplication
    {
        PropertyOwnerDto CreateRecord(PropertyOwnerDto record);
        bool DeleteRecord(int recordId);
        int UpdateRecord(PropertyOwnerDto record);
        PropertyOwnerDto GetRecord(int recordId);
        IEnumerable<PropertyOwnerDto> GetAllRecords(string filter);
    }
}
