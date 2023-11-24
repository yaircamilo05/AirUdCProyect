using AirbnbUdC.Application.Contracts.DTO.Manager;
using AirUdC.GUI.Models.Manager;
using System.Collections.Generic;

namespace AirUdC.GUI.Mappers.Manager
{
    public class PropertyMultimediaMapperGUI : MapperBaseGUI<PropertyMultimediaDto, PropertyMultimediaModel>
    {
        public override IEnumerable<PropertyMultimediaModel> MapListT1toT2(IEnumerable<PropertyMultimediaDto> value)
        {
            IList<PropertyMultimediaModel> list = new List<PropertyMultimediaModel>();
            foreach (var customer in value)
            {
                list.Add(MapT1toT2(customer));
            }
            return list;
        }

        public override IEnumerable<PropertyMultimediaDto> MapListT2toT1(IEnumerable<PropertyMultimediaModel> value)
        {
            IList<PropertyMultimediaDto> list = new List<PropertyMultimediaDto>();
            foreach (var customer in value)
            {
                list.Add(MapT2toT1(customer));
            }
            return list;
        }

        public override PropertyMultimediaModel MapT1toT2(PropertyMultimediaDto value)
        {
            return new PropertyMultimediaModel()
            {
                PropertyMultimediaId = value.PropertyMultimediaId,
                MultimediaName = value.MultimediaName,
                MultimediaLink = value.MultimediaLink,
                Property = value.Property,
                MultimediaType = value.MultimediaType
            };
        }

        public override PropertyMultimediaDto MapT2toT1(PropertyMultimediaModel value)
        {
            return new PropertyMultimediaDto()
            {
                PropertyMultimediaId = value.PropertyMultimediaId,
                MultimediaName = value.MultimediaName,
                MultimediaLink = value.MultimediaLink,
                Property = value.Property,
                MultimediaType = value.MultimediaType
            };
        }
    }

}