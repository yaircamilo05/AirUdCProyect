using AirbnbUdC.Repository.Contracts.DbModel.Parameters;
using System.Collections.Generic;

namespace AirbnbUdC.Repository.Contracts.Contrats.Parameters
{
    public interface ICityRepository
    {
        CityDbModel CreateRecord (CityDbModel record);
        bool DeleteRecord(int  recordId);
        int UpdateRecord(CityDbModel record);
        CityDbModel GetRecord(int recordId);
        IEnumerable<CityDbModel> GetAllRecords(string filter);
        IEnumerable<CityDbModel> GetAllRecordsByCountryId(int countryId);

    }
}
