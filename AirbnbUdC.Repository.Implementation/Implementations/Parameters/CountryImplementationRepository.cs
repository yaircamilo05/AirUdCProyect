using AirbnbUdC.Repository.Contracts.Contrats.Parameters;
using AirbnbUdC.Repository.Contracts.DbModel.Parameters;
using AirbnbUdC.Repository.Implementation.DataModel;
using AirbnbUdC.Repository.Implementation.Mappers.parameters;
using System.Collections.Generic;
using System.Linq;
using Utilities.Exceptions;
using Utilities.Messages;

namespace AirbnbUdC.Repository.Implementation.Implementations.Parameters
{
    public class CountryImplementationRepository : ICountryRepository
    {
        public CountryDbModel CreateRecord(CountryDbModel record)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                if (db.Country.Any(country => country.CountryName.Equals(record.CountryName)))
                    throw new AirException(MessagesCountry.CountryExit);
                
                else
                {
                    CountryMapperRepository countryMapperRepository = new CountryMapperRepository();
                    var country = countryMapperRepository.MapT2toT1(record);
                    var countryDb = db.Country.Add(country);
                    db.SaveChangesAsync();
                    var response = countryMapperRepository.MapT1toT2(countryDb);
                    return response;
                }
            }
        }

        public int DeleteRecord(int recordId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<CountryDbModel> GetAllRecords()
        {
            throw new System.NotImplementedException();
        }

        public CountryDbModel GetRecord(int recordId)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateRecord(CountryDbModel record)
        {
            throw new System.NotImplementedException();
        }
    }
}
