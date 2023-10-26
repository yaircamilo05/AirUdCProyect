using AirbnbUdC.Repository.Contracts.DbModel.Parameters;
using System.Collections.Generic;

namespace AirbnbUdC.Repository.Contracts.Contrats.Parameters
{
    public interface ICountryRepository
    {
        CountryDbModel CreateRecord (CountryDbModel record);
        bool DeleteRecord(int  recordId);
        int UpdateRecord(CountryDbModel record);
        CountryDbModel GetRecord(int recordId);
        IEnumerable<CountryDbModel> GetAllRecords(string filter);

    }
}
