using AirbnbUdC.Repository.Contracts.DbModel.Parameters;
using AirbnbUdC.Repository.Implementation.DataModel;
using System.Collections.Generic;

namespace AirbnbUdC.Repository.Implementation.Mappers.parameters
{
    public class CountryMapperRepository : BaseMapperRepository<Country, CountryDbModel>
    {
        public override IEnumerable<CountryDbModel> MapListT1toT2(IEnumerable<Country> value)
        {
           foreach (var country in value)
            {
                yield return MapT1toT2(country);
            }
        }

        public override IEnumerable<Country> MapListT2toT1(IEnumerable<CountryDbModel> value)
        {
            foreach (var country in value)
            {
                yield return MapT2toT1(country);
            }
        }

        public override CountryDbModel MapT1toT2(Country value)
        {
            return new CountryDbModel()
            {
                CountryName = value.CountryName
            };
        }

        public override Country MapT2toT1(CountryDbModel value)
        {
            return new Country()
            {
                CountryName = value.CountryName
            };
        }
    }
}
