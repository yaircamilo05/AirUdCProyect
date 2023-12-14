using AirbnbUdC.Application.Contracts.DTO.Parameters;
using AirUdC.GUI.Models.Parameters;
using System.Collections.Generic;

namespace AirUdC.GUI.Mappers.Parameters
{
    public class CityMapperGUI : MapperBaseGUI<CityDto, CityModel>
    {
        private CountryMapperGUI _countryMapperGUI;
        public CityMapperGUI() { 
            _countryMapperGUI = new CountryMapperGUI();
        }
        public override IEnumerable<CityModel> MapListT1toT2(IEnumerable<CityDto> value)
        {
            IList<CityModel> list = new List<CityModel>();
            foreach (var city in value)
            {
                list.Add(MapT1toT2(city));
            }
            return list;
        }

        public override IEnumerable<CityDto> MapListT2toT1(IEnumerable<CityModel> value)
        {
            IList<CityDto> list = new List<CityDto>();
            foreach (var city in value)
            {
                list.Add(MapT2toT1(city));
            }
            return list;
        }

        public override CityModel MapT1toT2(CityDto value)
        {
            return new CityModel
            {
                CityId = value.CityId,
                CityName = value.CityName,
                Country = _countryMapperGUI.MapT1toT2(value.Country)
            };
        }

        public override CityDto MapT2toT1(CityModel value)
        {
           if (value == null)
            {
               return new CityDto();
           }
           return new CityDto
           {
               CityId = value.CityId,
               CityName = value.CityName,
               Country = _countryMapperGUI.MapT2toT1(value.Country)
           };
        }
    }
}