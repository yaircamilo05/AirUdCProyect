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
            foreach (var country in value)
            {
                yield return MapT1toT2(country);
            }
        }

        public override IEnumerable<CityDto> MapListT2toT1(IEnumerable<CityModel> value)
        {
            foreach (var country in value)
            {
                yield return MapT2toT1(country);
            }
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
           return new CityDto
           {
               CityId = value.CityId,
               CityName = value.CityName,
               Country = _countryMapperGUI.MapT2toT1(value.Country)
           };
        }
    }
}