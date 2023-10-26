using AirbnbUdC.Repository.Contracts.DbModel.Manager;
using System.Collections.Generic;

namespace AirbnbUdC.Repository.Contracts.Contrats.Manager
{
    public interface IPropertyMultimediaRepository
    {
        PropertyMultimediaDbModel CreateRecord(PropertyMultimediaDbModel record);
        bool DeleteRecord(int recordId);
        int UpdateRecord(PropertyMultimediaDbModel record);
        PropertyMultimediaDbModel GetRecord(int recordId);
        IEnumerable<PropertyMultimediaDbModel> GetAllRecords();
        IEnumerable<PropertyMultimediaDbModel> GetAllRecordsByPropertyId(long propertyId);
        IEnumerable<PropertyMultimediaDbModel> GetAllRecordsByPropertyIdAndType(long propertyId, long multimediaTypeId);
    }
}
