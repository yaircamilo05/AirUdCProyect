using AirbnbUdC.Repository.Contracts.DbModel.Parameters;
using AirbnbUdC.Repository.Implementation.DataModel;
using System.Collections.Generic;

namespace AirbnbUdC.Repository.Implementation.Mappers.Parameters
{
    public class MultimediaTypeMapperRepository : BaseMapperRepository<MultimediaType, MultimediaTypeDbModel>
    {
        public override MultimediaTypeDbModel MapT1toT2(MultimediaType value)
        {
            return new MultimediaTypeDbModel()
            {
                MultimediaTypeId = value.Id,
                MultimediaTypeName = value.MultimediaTypeName
            };
        }

        public override MultimediaType MapT2toT1(MultimediaTypeDbModel value)
        {
            return new MultimediaType()
            {
                Id = value.MultimediaTypeId,
                MultimediaTypeName = value.MultimediaTypeName
            };
        }

        public override IEnumerable<MultimediaTypeDbModel> MapListT1toT2(IEnumerable<MultimediaType> value)
        {
            foreach (var multimediaType in value)
            {
                yield return MapT1toT2(multimediaType);
            }
        }

        public override IEnumerable<MultimediaType> MapListT2toT1(IEnumerable<MultimediaTypeDbModel> value)
        {
            foreach (var multimediaType in value)
            {
                yield return MapT2toT1(multimediaType);
            }
        }
    }
}
