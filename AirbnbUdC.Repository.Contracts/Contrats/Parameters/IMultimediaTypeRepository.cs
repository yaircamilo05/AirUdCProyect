using AirbnbUdC.Repository.Contracts.DbModel.Parameters;
using System.Collections.Generic;

namespace AirbnbUdC.Repository.Contracts.Contrats.Parameters
{
    public interface IMultimediaTypeRepository
    {
        MultimediaTypeDbModel CreateRecord(MultimediaTypeDbModel record);
        bool DeleteRecord(int recordId);
        int UpdateRecord(MultimediaTypeDbModel record);
        MultimediaTypeDbModel GetRecord(int recordId);
        IEnumerable<MultimediaTypeDbModel> GetAllRecords(string filter);
        
    }
}
