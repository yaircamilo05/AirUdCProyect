using AirbnbUdC.Application.Contracts.DTO.Parameters;
using AirUdC.GUI.Models.Parameters;
using System.Collections.Generic;

namespace AirUdC.GUI.Mappers.Parameters
{
    public class MultimediaTypeMapperGUI : MapperBaseGUI<MultimediaTypeDto, MultimediaTypeModel>
    {
        public override IEnumerable<MultimediaTypeModel> MapListT1toT2(IEnumerable<MultimediaTypeDto> value)
        {
            IList<MultimediaTypeModel> list = new List<MultimediaTypeModel>();
            foreach (var multimediaType in value)
            {
                list.Add(MapT1toT2(multimediaType));
            }
            return list; ;
        }

        public override IEnumerable<MultimediaTypeDto> MapListT2toT1(IEnumerable<MultimediaTypeModel> value)
        {
            IList<MultimediaTypeDto> list = new List<MultimediaTypeDto>();
            foreach (var multimediaType in value)
            {
                list.Add(MapT2toT1(multimediaType));
            }
            return list;
        }

        public override MultimediaTypeModel MapT1toT2(MultimediaTypeDto value)
        {
            return new MultimediaTypeModel
            {
                MultimediaTypeId = value.MultimediaTypeId,
                MultimediaTypeName = value.MultimediaTypeName
            };
        }

        public override MultimediaTypeDto MapT2toT1(MultimediaTypeModel value)
        {
            return new MultimediaTypeDto
            {
                MultimediaTypeId = value.MultimediaTypeId,
                MultimediaTypeName = value.MultimediaTypeName
            };
        }
    }
}