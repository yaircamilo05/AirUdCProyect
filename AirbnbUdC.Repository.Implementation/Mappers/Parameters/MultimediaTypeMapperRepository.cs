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
            IList<MultimediaTypeDbModel> list = new List<MultimediaTypeDbModel>();
            foreach (var type in value)
            {
                list.Add(MapT1toT2(type));
            }
            return list;
        }

        public override IEnumerable<MultimediaType> MapListT2toT1(IEnumerable<MultimediaTypeDbModel> value)
        {
            IList<MultimediaType> list = new List<MultimediaType>();
            foreach (var type in value)
            {
                list.Add(MapT2toT1(type));
            }
            return list;
        }
    }
}
