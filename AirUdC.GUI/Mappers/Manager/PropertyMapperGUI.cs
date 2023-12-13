using AirbnbUdC.Application.Contracts.DTO.Manager;
using AirbnbUdC.Repository.Implementation.DataModel;
using AirUdC.GUI.Mappers.Parameters;
using AirUdC.GUI.Models.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirUdC.GUI.Mappers.Manager
{
    public class PropertyMapperGUI : MapperBaseGUI<PropertyDto, PropertyModel>
    {   
        private PropertyOwnerMapperGUI _propertyOwnerMapperGUI;
        private CityMapperGUI _cityMapperGUI;
        public override IEnumerable<PropertyModel> MapListT1toT2(IEnumerable<PropertyDto> value)
        {
            IList<PropertyModel> list = new List<PropertyModel>();
            foreach (var property in value)
            {
                list.Add(MapT1toT2(property));
            }
            return list;
        }

        public override IEnumerable<PropertyDto> MapListT2toT1(IEnumerable<PropertyModel> value)
        {
            IList<PropertyDto> list = new List<PropertyDto>();
            foreach (var property in value)
            {
                list.Add(MapT2toT1(property));
            }
            return list;
        }

        public override PropertyModel MapT1toT2(PropertyDto value)
        {
            return new PropertyModel()
            {
                PropertyId = value.PropertyId,
                PropertyAddress = value.PropertyAddress,
                Price = value.Price,
                city = _cityMapperGUI.MapT1toT2(value.city),
                PropertyOwner = _propertyOwnerMapperGUI.MapT1toT2(value.PropertyOwner),
                CustomerAmount = value.CustomerAmount,
                Latitude = value.Latitude,
                Longitude = value.Longitude,
                CheckinData = value.CheckinData,
                CheckoutData = value.CheckoutData,
                Details = value.Details,
                Pets = value.Pets,
                Freezer = value.Freezer,
                LaundryService = value.LaundryService
                
            };
        }

        public override PropertyDto MapT2toT1(PropertyModel value)
        {
            return new PropertyDto()
            {
                PropertyId = value.PropertyId,
                PropertyAddress = value.PropertyAddress,
                Price = value.Price,
                city = _cityMapperGUI.MapT2toT1(value.city),
                PropertyOwner = _propertyOwnerMapperGUI.MapT2toT1(value.PropertyOwner),
                CustomerAmount = value.CustomerAmount,
                Latitude = value.Latitude,
                Longitude = value.Longitude,
                CheckinData = value.CheckinData,
                CheckoutData = value.CheckoutData,
                Details = value.Details,
                Pets = value.Pets,
                Freezer = value.Freezer,
                LaundryService = value.LaundryService

            };
        }
    }
}