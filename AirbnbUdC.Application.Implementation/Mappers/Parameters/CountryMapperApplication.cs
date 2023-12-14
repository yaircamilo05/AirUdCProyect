using AirbnbUdC.Application.Contracts.DTO.Parameters;
using AirbnbUdC.Repository.Contracts.DbModel.Parameters;
using System.Collections.Generic;

namespace AirbnbUdC.Application.Implementation.Mappers.Parameters
{
    public class CountryMapperApplication : BaseMapperApplication<CountryDbModel, CountryDto>
    {
        public override IEnumerable<CountryDto> MapListT1toT2(IEnumerable<CountryDbModel> value)
        {
            IList<CountryDto> list = new List<CountryDto>();
            foreach (var country in value)
            {
                list.Add(MapT1toT2(country));
            }
            return list;
        }

        public override IEnumerable<CountryDbModel> MapListT2toT1(IEnumerable<CountryDto> value)
        {
            foreach (var country in value)
            {
                yield return MapT2toT1(country);
            }
        }

        public override CountryDto MapT1toT2(CountryDbModel value)
        {
            if (value == null)
            {
                return new CountryDto();
            }   
            return new CountryDto()
            {
                CountryId = value.CountryId,
                CountryName = value.CountryName
            };
        }

        public override CountryDbModel MapT2toT1(CountryDto value)
        {
            return new CountryDbModel()
            {
                CountryId = value.CountryId,
                CountryName = value.CountryName
            };
        }
    }
}
