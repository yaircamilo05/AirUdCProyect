using AirbnbUdC.Repository.Contracts.DbModel.Manager;
using AirbnbUdC.Repository.Implementation.DataModel;
using System.Collections.Generic;

namespace AirbnbUdC.Repository.Implementation.Mappers.Manager
{
    public class PropertyOwnerMapperRepository : BaseMapperRepository<PropertyOwner, PropertyOwnerDbModel>
    {
        public override IEnumerable<PropertyOwnerDbModel> MapListT1toT2(IEnumerable<PropertyOwner> value)
        {
            IList<PropertyOwnerDbModel> list = new List<PropertyOwnerDbModel>();
            foreach (var owner in value)
            {
                list.Add(MapT1toT2(owner));
            }
            return list;
        }

        public override IEnumerable<PropertyOwner> MapListT2toT1(IEnumerable<PropertyOwnerDbModel> value)
        {
            IList<PropertyOwner> list = new List<PropertyOwner>();
            foreach (var owner in value)
            {
                list.Add(MapT2toT1(owner));
            }
            return list;
        }

        public override PropertyOwnerDbModel MapT1toT2(PropertyOwner value)
        {
            return new PropertyOwnerDbModel()
            {
                PropertyOwnerId = value.Id,
                FirstName = value.FirstName,
                FamilyName = value.FamilyName,
                Email = value.Email,
                Cellphone = value.Cellphone,
                Photo = value.Photo
            };
        }

        public override PropertyOwner MapT2toT1(PropertyOwnerDbModel value)
        {
            return new PropertyOwner()
            {
                Id = value.PropertyOwnerId,
                FirstName = value.FirstName,
                FamilyName = value.FamilyName,
                Email = value.Email,
                Cellphone = value.Cellphone,
                Photo = value.Photo
            };
        }
    }
}
