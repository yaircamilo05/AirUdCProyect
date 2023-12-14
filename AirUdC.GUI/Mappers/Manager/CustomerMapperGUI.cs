using AirbnbUdC.Application.Contracts.DTO.Manager;
using AirUdC.GUI.Models.Manager;
using System.Collections.Generic;

namespace AirUdC.GUI.Mappers.Manager
{
    public class CustomerMapperGUI : MapperBaseGUI<CustomerDto, CustomerModel>
    {
        public override IEnumerable<CustomerModel> MapListT1toT2(IEnumerable<CustomerDto> value)
        {
            IList<CustomerModel> list = new List<CustomerModel>();
            foreach (var customer in value)
            {
                list.Add(MapT1toT2(customer));
            }
            return list;
        }

        public override IEnumerable<CustomerDto> MapListT2toT1(IEnumerable<CustomerModel> value)
        {
            IList<CustomerDto> list = new List<CustomerDto>();
            foreach (var customer in value)
            {
                list.Add(MapT2toT1(customer));
            }
            return list;
        }

        public override CustomerModel MapT1toT2(CustomerDto value)
        {
            return new CustomerModel()
            {
                CustomerId = value.CustomerId,
                FirstName = value.FirstName,
                FamilyName = value.FamilyName,
                Email = value.Email,
                Cellphone = value.Cellphone,
                Photo = value.Photo
            };
        }

        public override CustomerDto MapT2toT1(CustomerModel value)
        {
            if (value == null) return new CustomerDto();
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
    }
}