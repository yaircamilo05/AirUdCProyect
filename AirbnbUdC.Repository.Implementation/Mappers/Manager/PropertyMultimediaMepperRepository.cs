using AirbnbUdC.Repository.Contracts.DbModel.Manager;
using AirbnbUdC.Repository.Implementation.DataModel;
using AirbnbUdC.Repository.Implementation.Mappers.Parameters;
using System.Collections.Generic;

namespace AirbnbUdC.Repository.Implementation.Mappers.Manager
{
    public class PropertyMultimediaMepperRepository : BaseMapperRepository<PropertyMultimedia, PropertyMultimediaDbModel>
    {
        private readonly MultimediaTypeMapperRepository _multimediaTypeMapper;
        public PropertyMultimediaMepperRepository()
        {
            _multimediaTypeMapper = new MultimediaTypeMapperRepository();
        }
        public override IEnumerable<PropertyMultimediaDbModel> MapListT1toT2(IEnumerable<PropertyMultimedia> value)
        {
            foreach (var PropertyMultimedia in value)
            {
                yield return MapT1toT2(PropertyMultimedia);
            }
        }

        public override IEnumerable<PropertyMultimedia> MapListT2toT1(IEnumerable<PropertyMultimediaDbModel> value)
        {
            foreach (var PropertyMultimedia in value)
            {
                yield return MapT2toT1(PropertyMultimedia);
            }
        }

        public override PropertyMultimediaDbModel MapT1toT2(PropertyMultimedia value)
        {
            return new PropertyMultimediaDbModel()
            {
               PropertyMultimediaId = value.Id,
               MultimediaName = value.MultimediaName,
               MultimediaLink = value.MultimediaLink,
              // Property = value.Property,
               MultimediaType = _multimediaTypeMapper.MapT1toT2(value.MultimediaType)
            };
        }

        public override PropertyMultimedia MapT2toT1(PropertyMultimediaDbModel value)
        {
            return new PropertyMultimedia()
            {
                Id = value.PropertyMultimediaId,
                MultimediaName = value.MultimediaName,
                MultimediaLink = value.MultimediaLink,
                // Property = value.Property,
                MultimediaType = _multimediaTypeMapper.MapT2toT1(value.MultimediaType)
            };
        }
    }
}
