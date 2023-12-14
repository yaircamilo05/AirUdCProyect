using AirbnbUdC.Application.Contracts.DTO.Manager;
using AirUdC.GUI.Models.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirUdC.GUI.Mappers.Manager
{
    public class PropertyOwnerMapperGUI : MapperBaseGUI<PropertyOwnerDto, PropertyOwnerModel>
    {
        public override IEnumerable<PropertyOwnerModel> MapListT1toT2(IEnumerable<PropertyOwnerDto> value)
        {
            IList<PropertyOwnerModel> list = new List<PropertyOwnerModel>();
            foreach (var propertyOwner in value)
            {
                list.Add(MapT1toT2(propertyOwner));
            }
            return list;
        }

        public override IEnumerable<PropertyOwnerDto> MapListT2toT1(IEnumerable<PropertyOwnerModel> value)
        {
            IList<PropertyOwnerDto> list = new List<PropertyOwnerDto>();
            foreach (var propertyOwner in value)
            {
                list.Add(MapT2toT1(propertyOwner));
            }
            return list;
        }

        public override PropertyOwnerModel MapT1toT2(PropertyOwnerDto value)
        {
            return new PropertyOwnerModel()
            {
                PropertyOwnerId = value.PropertyOwnerId,
                FirstName = value.FirstName,
                FamilyName = value.FamilyName,
                Email = value.Email,
                Cellphone = value.Cellphone,
                Photo = value.Photo
            };  
        }

        public override PropertyOwnerDto MapT2toT1(PropertyOwnerModel value)
        {
            if (value == null)
            {
                return null;
            }
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
    }
}