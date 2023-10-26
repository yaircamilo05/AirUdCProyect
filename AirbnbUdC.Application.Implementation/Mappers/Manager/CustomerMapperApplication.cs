using AirbnbUdC.Application.Contracts.DTO.Manager;
using AirbnbUdC.Repository.Contracts.DbModel.Manager;
using System.Collections.Generic;

namespace AirbnbUdC.Application.Implementation.Mappers.Manager
{
    public class CustomerMapperApplication: BaseMapperApplication<CustomerDbModel, CustomerDto>
    {
        public override IEnumerable<CustomerDto> MapListT1toT2(IEnumerable<CustomerDbModel> value)
        {
            foreach (var Customer in value)
            {
                yield return MapT1toT2(Customer);
            }
        }

        public override IEnumerable<CustomerDbModel> MapListT2toT1(IEnumerable<CustomerDto> value)
        {
            foreach (var Customer in value)
            {
                yield return MapT2toT1(Customer);
            }
        }

        public override CustomerDto MapT1toT2(CustomerDbModel value)
        {
            return new CustomerDto()
            {
                CustomerId = value.CustomerId,
                FirstName = value.FirstName,
                FamilyName = value.FamilyName,
                Email = value.Email,
                Cellphone = value.Cellphone,
                Photo = value.Photo
            };
        }

        public override CustomerDbModel MapT2toT1(CustomerDto value)
        {
            return new CustomerDbModel()
            {
                CustomerId = value.CustomerId,
                FirstName = value.FirstName,
                FamilyName = value.FamilyName,
                Email = value.Email,
                Cellphone = value.Cellphone,
                Photo = value.Photo
            };
        }

    }
}
