using AirbnbUdC.Application.Contracts.DTO.Parameters;
using AirUdC.GUI.Models.Parameters;
using System.Collections.Generic;

namespace AirUdC.GUI.Mappers.Parameters
{
    public class CountryMapperGUI : MapperBaseGUI<CountryDto,CountryModel>
    {
        public override IEnumerable<CountryModel> MapListT1toT2(IEnumerable<CountryDto> value)
        {
            IList<CountryModel> list = new List<CountryModel>();
            foreach (var country in value)
            {
                list.Add(MapT1toT2(country));
            }
            return list;
        }

        public override IEnumerable<CountryDto> MapListT2toT1(IEnumerable<CountryModel> value)
        {
            IList<CountryDto> list = new List<CountryDto>();
            foreach (var country in value)
            {
                list.Add(MapT2toT1(country));
            }
            return list;
        }

        public override CountryModel MapT1toT2(CountryDto value)
        {
            return new CountryModel
            {
                CountryId = value.CountryId,
                CountryName = value.CountryName
            };
        }

        public override CountryDto MapT2toT1(CountryModel value)
        {
           return new CountryDto
           {
               CountryId = value.CountryId,
               CountryName = value.CountryName
           };
        }
    }
}