using AirbnbUdC.Application.Contracts.DTO.Parameters;
using AirbnbUdC.Repository.Contracts.DbModel.Parameters;
using System.Collections.Generic;

namespace AirbnbUdC.Application.Implementation.Mappers.Parameters
{
    public class MultimediaTypeMapperApplication : BaseMapperApplication<MultimediaTypeDbModel, MultimediaTypeDto>
    {
        public override MultimediaTypeDto MapT1toT2(MultimediaTypeDbModel value)
        {
            return new MultimediaTypeDto()
            {
                MultimediaTypeId = value.MultimediaTypeId,
                MultimediaTypeName = value.MultimediaTypeName
            };
        }

        public override MultimediaTypeDbModel MapT2toT1(MultimediaTypeDto value)
        {
            return new MultimediaTypeDbModel()
            {
                MultimediaTypeId = value.MultimediaTypeId,
                MultimediaTypeName = value.MultimediaTypeName
            };
        }

        public override IEnumerable<MultimediaTypeDto> MapListT1toT2(IEnumerable<MultimediaTypeDbModel> value)
        {
            IList<MultimediaTypeDto> list = new List<MultimediaTypeDto>();
            foreach (var city in value)
            {
                list.Add(MapT1toT2(city));
            }
            return list;
        }

        public override IEnumerable<MultimediaTypeDbModel> MapListT2toT1(IEnumerable<MultimediaTypeDto> value)
        {
            IList<MultimediaTypeDbModel> list = new List<MultimediaTypeDbModel>();
            foreach (var city in value)
            {
                list.Add(MapT2toT1(city));
            }
            return list;
        }
    }
}
