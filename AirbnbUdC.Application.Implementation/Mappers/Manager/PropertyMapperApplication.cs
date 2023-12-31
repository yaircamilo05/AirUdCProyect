﻿using AirbnbUdC.Application.Contracts.DTO.Manager;
using AirbnbUdC.Application.Implementation.Mappers.Parameters;
using AirbnbUdC.Repository.Contracts.DbModel.Manager;
using System.Collections.Generic;

namespace AirbnbUdC.Application.Implementation.Mappers.Manager
{
    public class PropertyMapperApplication : BaseMapperApplication<PropertyDbModel, PropertyDto>
    {
        public override IEnumerable<PropertyDto> MapListT1toT2(IEnumerable<PropertyDbModel> value)
        {
            foreach (var property in value)
            {
                yield return MapT1toT2(property);
            }
        }

        public override IEnumerable<PropertyDbModel> MapListT2toT1(IEnumerable<PropertyDto> value)
        {
            foreach (var property in value)
            {
                yield return MapT2toT1(property);
            }
        }

        public override PropertyDto MapT1toT2(PropertyDbModel value)
        {
            //creame el objeto de tipo PropertyDto todos los datos se llaman igual
            return new PropertyDto()
            {
                PropertyId = value.PropertyId,
                PropertyAddress = value.PropertyAddress,
                city = new CityMapperApplication().MapT1toT2(value.city),
                PropertyOwner = new PropertyOwnerMapperApplication().MapT1toT2(value.PropertyOwner),
                CustomerAmount = value.CustomerAmount,
                Price = value.Price,
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

        public override PropertyDbModel MapT2toT1(PropertyDto value)
        {
            return new PropertyDbModel()
            {
                PropertyId = value.PropertyId,
                PropertyAddress = value.PropertyAddress,
                city = new CityMapperApplication().MapT2toT1(value.city),
                PropertyOwner = new PropertyOwnerMapperApplication().MapT2toT1(value.PropertyOwner),
                CustomerAmount = value.CustomerAmount,
                Price = value.Price,
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
