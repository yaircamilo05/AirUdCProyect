using AirbnbUdC.Repository.Contracts.DbModel.Manager;
using System.Collections.Generic;

namespace AirbnbUdC.Repository.Contracts.Contrats.Manager
{
    public interface IPropertyOwnerRepository
    {
        PropertyOwnerDbModel CreateRecord(PropertyOwnerDbModel record);
        bool DeleteRecord(long recordId);
        int UpdateRecord(PropertyOwnerDbModel record);
        PropertyOwnerDbModel GetRecord(long recordId);
        IEnumerable<PropertyOwnerDbModel> GetAllRecords(string filters);

    }
}
