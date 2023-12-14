using AirbnbUdC.Repository.Contracts.DbModel.Parameters;
using AirbnbUdC.Repository.Implementation.DataModel;
using System.Collections.Generic;

namespace AirbnbUdC.Repository.Implementation.Mappers.parameters
{
    public class CityMapperRepository : BaseMapperRepository<City, CityDbModel>
    {
        public override IEnumerable<CityDbModel> MapListT1toT2(IEnumerable<City> value)
        {
            IList<CityDbModel> list = new List<CityDbModel>();
            foreach (var city in value)
            {
                list.Add(MapT1toT2(city));
            }
            return list;
        }

        public override IEnumerable<City> MapListT2toT1(IEnumerable<CityDbModel> value)
        {
            IList<City> list = new List<City>();
            foreach (var city in value)
            {
                list.Add(MapT2toT1(city));
            }
            return list;
        }

        public override CityDbModel MapT1toT2(City value)
        {
            if (value == null)
            {
                return new CityDbModel();
            }
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
                CountryId = value.Country.CountryId,
            };
        }
    }
}
