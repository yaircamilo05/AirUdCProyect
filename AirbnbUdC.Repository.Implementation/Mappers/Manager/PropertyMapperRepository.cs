using AirbnbUdC.Repository.Contracts.DbModel.Manager;
using AirbnbUdC.Repository.Implementation.DataModel;
using AirbnbUdC.Repository.Implementation.Mappers.parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirbnbUdC.Repository.Implementation.Mappers.Manager
{
    public class PropertyMapperRepository : BaseMapperRepository<Property, PropertyDbModel>
    {
        public override IEnumerable<PropertyDbModel> MapListT1toT2(IEnumerable<Property> value)
        {
            foreach (var property in value)
            {
                yield return MapT1toT2(property);
            }
        }

        public override IEnumerable<Property> MapListT2toT1(IEnumerable<PropertyDbModel> value)
        {
            foreach (var property in value)
            {
                yield return MapT2toT1(property);
            }
        }

        public override PropertyDbModel MapT1toT2(Property value)
        {
            return new PropertyDbModel()
            {
                PropertyId = value.Id,
                PropertyAddress = value.PropertyAddress,
                city = new CityMapperRepository().MapT1toT2(value.City),
                PropertyOwner = new PropertyOwnerMapperRepository().MapT1toT2(value.PropertyOwner),
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

        public override Property MapT2toT1(PropertyDbModel value)
        {
            return new Property()
            {
                Id = value.PropertyId,
                PropertyAddress = value.PropertyAddress,
                City = new CityMapperRepository().MapT2toT1(value.city),
                PropertyOwner = new PropertyOwnerMapperRepository().MapT2toT1(value.PropertyOwner),
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
