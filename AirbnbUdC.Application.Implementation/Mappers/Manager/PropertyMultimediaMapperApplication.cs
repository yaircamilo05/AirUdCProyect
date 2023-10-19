using AirbnbUdC.Application.Contracts.DTO.Manager;
using AirbnbUdC.Application.Implementation.Mappers.Parameters;
using AirbnbUdC.Repository.Contracts.DbModel.Manager;
using System.Collections.Generic;

namespace AirbnbUdC.Application.Implementation.Mappers.Manager
{
    public class PropertyMultimediaMapperApplication : BaseMapperApplication<PropertyMultimediaDbModel, PropertyMultimediaDto>
    {
        private readonly PropertyMultimediaMapperApplication _propertyMultimediaMapper;
        private readonly MultimediaTypeMapperApplication _multimediaTypeMapper;
        public PropertyMultimediaMapperApplication()
        {
            _propertyMultimediaMapper = new PropertyMultimediaMapperApplication();
            _multimediaTypeMapper = new MultimediaTypeMapperApplication();
        }
        public override IEnumerable<PropertyMultimediaDto> MapListT1toT2(IEnumerable<PropertyMultimediaDbModel> value)
        {
            foreach (var PropertyMultimedia in value)
            {
                yield return MapT1toT2(PropertyMultimedia);
            }
        }

        public override IEnumerable<PropertyMultimediaDbModel> MapListT2toT1(IEnumerable<PropertyMultimediaDto> value)
        {
            foreach (var PropertyMultimedia in value)
            {
                yield return MapT2toT1(PropertyMultimedia);
            }
        }

        public override PropertyMultimediaDto MapT1toT2(PropertyMultimediaDbModel value)
        {
            return new PropertyMultimediaDto()
            {
                PropertyMultimediaId = value.PropertyMultimediaId,
                MultimediaName = value.MultimediaName,
                MultimediaLink = value.MultimediaLink,
                // Property = value.Property,
                MultimediaType = _multimediaTypeMapper.MapT1toT2(value.MultimediaType)

            };
        }

        public override PropertyMultimediaDbModel MapT2toT1(PropertyMultimediaDto value)
        {
            return new PropertyMultimediaDbModel()
            {
                PropertyMultimediaId = value.PropertyMultimediaId,
                MultimediaName = value.MultimediaName,
                MultimediaLink = value.MultimediaLink,
                // Property = value.Property,
                MultimediaType = _multimediaTypeMapper.MapT2toT1(value.MultimediaType)
            };
        }
    }
}
