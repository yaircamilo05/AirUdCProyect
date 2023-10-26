using AirbnbUdC.Application.Contracts.DTO.Manager;
using AirbnbUdC.Repository.Contracts.DbModel.Manager;
using System.Collections.Generic;

namespace AirbnbUdC.Application.Implementation.Mappers.Manager
{
    public class PropertyOwnerMapperApplication : BaseMapperApplication<PropertyOwnerDbModel, PropertyOwnerDto>
    {
        public override IEnumerable<PropertyOwnerDto> MapListT1toT2(IEnumerable<PropertyOwnerDbModel> value)
        {
            IList<PropertyOwnerDto> list = new List<PropertyOwnerDto>();
            foreach (var owner in value)
            {
                list.Add(MapT1toT2(owner));
            }
            return list;
        }

        public override IEnumerable<PropertyOwnerDbModel> MapListT2toT1(IEnumerable<PropertyOwnerDto> value)
        {
            IList<PropertyOwnerDbModel> list = new List<PropertyOwnerDbModel>();
            foreach (var owner in value)
            {
                list.Add(MapT2toT1(owner));
            }
            return list;
        }

        public override PropertyOwnerDto MapT1toT2(PropertyOwnerDbModel value)
        {
            return new PropertyOwnerDto()
            {
                PropertyOwnerId = value.PropertyOwnerId,
                FirstName = value.FirstName,
                FamilyName = value.FamilyName,
                Email = value.Email,
                Cellphone = value.Cellphone,
                Photo = value.Photo
            };
        }

        public override PropertyOwnerDbModel MapT2toT1(PropertyOwnerDto value)
        {
            return new PropertyOwnerDbModel()
            {
                PropertyOwnerId = value.PropertyOwnerId,
                FirstName = value.FirstName,
                FamilyName = value.FamilyName,
                Email = value.Email,
                Cellphone = value.Cellphone,
                Photo = value.Photo
            };
        }
    }
}
