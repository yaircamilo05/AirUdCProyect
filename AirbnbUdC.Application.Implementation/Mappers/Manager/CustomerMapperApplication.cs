using AirbnbUdC.Application.Contracts.DTO.Manager;
using AirbnbUdC.Application.Contracts.DTO.Parameters;
using AirbnbUdC.Repository.Contracts.DbModel.Manager;
using System.Collections.Generic;

namespace AirbnbUdC.Application.Implementation.Mappers.Manager
{
    public class CustomerMapperApplication: BaseMapperApplication<CustomerDbModel, CustomerDto>
    {
        public override IEnumerable<CustomerDto> MapListT1toT2(IEnumerable<CustomerDbModel> value)
        {
            IList<CustomerDto> list = new List<CustomerDto>();
            foreach (var customer in value)
            {
                list.Add(MapT1toT2(customer));
            }
            return list;
        }

        public override IEnumerable<CustomerDbModel> MapListT2toT1(IEnumerable<CustomerDto> value)
        {
            IList<CustomerDbModel> list = new List<CustomerDbModel>();
            foreach (var customer in value)
            {
                list.Add(MapT2toT1(customer));
            }
            return list;
        }

        public override CustomerDto MapT1toT2(CustomerDbModel value)
        {
            if (value == null)
            {
                return new CustomerDto();
            }
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
