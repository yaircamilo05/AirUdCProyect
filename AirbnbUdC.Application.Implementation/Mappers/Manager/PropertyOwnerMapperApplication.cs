using AirbnbUdC.Application.Contracts.DTO.Manager;
using AirbnbUdC.Repository.Contracts.DbModel.Manager;
using System.Collections.Generic;

namespace AirbnbUdC.Application.Implementation.Mappers.Manager
{
    public class PropertyOwnerMapperApplication : BaseMapperApplication<PropertyOwnerDbModel, PropertyOwnerDto>
    {
        public override IEnumerable<PropertyOwnerDto> MapListT1toT2(IEnumerable<PropertyOwnerDbModel> value)
        {
            foreach (var propertyOwner in value)
            {
                yield return MapT1toT2(propertyOwner);
            }
        }

        public override IEnumerable<PropertyOwnerDbModel> MapListT2toT1(IEnumerable<PropertyOwnerDto> value)
        {
            foreach (var propertyOwner in value)
            {
                yield return MapT2toT1(propertyOwner);
            }
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
