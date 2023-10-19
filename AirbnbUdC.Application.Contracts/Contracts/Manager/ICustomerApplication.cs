using AirbnbUdC.Application.Contracts.DTO.Manager;
using System.Collections.Generic;

namespace AirbnbUdC.Application.Contracts.Contracts.Manager
{
    public interface ICustomerApplication
    {
        CustomerDto CreateRecord(CustomerDto record);
        bool DeleteRecord(int recordId);
        int UpdateRecord(CustomerDto record);
        CustomerDto GetRecord(int recordId);
        IEnumerable<CustomerDto> GetAllRecords(string filter);
    }
}
