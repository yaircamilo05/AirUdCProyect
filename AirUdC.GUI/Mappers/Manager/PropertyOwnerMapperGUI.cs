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
            throw new NotImplementedException();
        }

        public override IEnumerable<PropertyOwnerDto> MapListT2toT1(IEnumerable<PropertyOwnerModel> value)
        {
            throw new NotImplementedException();
        }

        public override PropertyOwnerModel MapT1toT2(PropertyOwnerDto value)
        {
            throw new NotImplementedException();
        }

        public override PropertyOwnerDto MapT2toT1(PropertyOwnerModel value)
        {
            throw new NotImplementedException();
        }
    }
}