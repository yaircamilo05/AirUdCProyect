using AirbnbUdC.Repository.Contracts.DbModel.Parameters;
using System.Collections.Generic;

namespace AirbnbUdC.Repository.Contracts.Contrats.Parameters
{
    public interface ICountryRepository
    {
        CountryDbModel CreateRecord (CountryDbModel record);
        int DeleteRecord(int  recordId);
        void UpdateRecord(CountryDbModel record);
        CountryDbModel GetRecord(int recordId);
        IEnumerable<CountryDbModel> GetAllRecords();

    }
}
