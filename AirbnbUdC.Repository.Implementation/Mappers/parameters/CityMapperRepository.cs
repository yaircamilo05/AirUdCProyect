using AirbnbUdC.Repository.Contracts.DbModel.Parameters;
using AirbnbUdC.Repository.Implementation.DataModel;
using System.Collections.Generic;

namespace AirbnbUdC.Repository.Implementation.Mappers.parameters
{
    public class CityMapperRepository : BaseMapperRepository<City, CityDbModel>
    {
        public override IEnumerable<CityDbModel> MapListT1toT2(IEnumerable<City> value)
        {
            foreach (var city in value)
            {
                yield return MapT1toT2(city);
            }
        }

        public override IEnumerable<City> MapListT2toT1(IEnumerable<CityDbModel> value)
        {
            foreach (var city in value)
            {
                yield return MapT2toT1(city);
            }
        }

        public override CityDbModel MapT1toT2(City value)
        {
            return new CityDbModel()
            {
                CityId = value.Id,
                CityName = value.CityName,
                Country = new CountryMapperRepository().MapT1toT2(value.Country)
            };
        }

        public override City MapT2toT1(CityDbModel value)
        {
            return new City()
            {
                Id = value.CityId,
                CityName = value.CityName,
                Country = new CountryMapperRepository().MapT2toT1(value.Country)
            };
        }
    }
}
