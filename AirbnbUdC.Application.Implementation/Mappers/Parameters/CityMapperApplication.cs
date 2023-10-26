using AirbnbUdC.Application.Contracts.DTO.Parameters;
using AirbnbUdC.Repository.Contracts.DbModel.Parameters;
using System.Collections.Generic;

namespace AirbnbUdC.Application.Implementation.Mappers.Parameters
{
    public class CityMapperApplication : BaseMapperApplication<CityDbModel, CityDto>
    {
        public override IEnumerable<CityDto> MapListT1toT2(IEnumerable<CityDbModel> value)
        {
            IList<CityDto> list = new List<CityDto>();
            foreach (var city in value)
            {
                list.Add(MapT1toT2(city));
            }
            return list;
        }

        public override IEnumerable<CityDbModel> MapListT2toT1(IEnumerable<CityDto> value)
        {
            IList<CityDbModel> list = new List<CityDbModel>();
            foreach (var city in value)
            {
                list.Add(MapT2toT1(city));
            }
            return list;
        }

        public override CityDto MapT1toT2(CityDbModel value)
        {
            return new CityDto()
            {
                CityId = value.CityId,
                CityName = value.CityName,
                Country = new CountryMapperApplication().MapT1toT2(value.Country)
            };
        }

        public override CityDbModel MapT2toT1(CityDto value)
        {
            return new CityDbModel()
            {
                CityId = value.CityId,
                CityName = value.CityName,
                Country = new CountryMapperApplication().MapT2toT1(value.Country)
            };
        }
    }
}

