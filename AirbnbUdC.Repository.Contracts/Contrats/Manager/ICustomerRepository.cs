
using AirbnbUdC.Repository.Contracts.DbModel.Manager;
using System.Collections.Generic;

namespace AirbnbUdC.Repository.Contracts.Contrats.Manager
{
    public interface ICustomerRepository
    {
        CustomerDbModel CreateRecord(CustomerDbModel record);
        bool DeleteRecord(long recordId);
        int UpdateRecord(CustomerDbModel record);
        CustomerDbModel GetRecord(long recordId);
        IEnumerable<CustomerDbModel> GetAllRecords(string filters);
    }
}
