using AirbnbUdC.Repository.Contracts.DbModel.Manager;
using AirbnbUdC.Repository.Implementation.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirbnbUdC.Repository.Implementation.Mappers.Manager
{
    public class CustomerMapperRepository: BaseMapperRepository<Customer, CustomerDbModel>
    {
        public override IEnumerable<CustomerDbModel> MapListT1toT2(IEnumerable<Customer> value)
        {
            foreach (var Customer in value)
            {
                yield return MapT1toT2(Customer);
            }
        }

        public override IEnumerable<Customer> MapListT2toT1(IEnumerable<CustomerDbModel> value)
        {
            foreach (var Customer in value)
            {
                yield return MapT2toT1(Customer);
            }
        }

        public override CustomerDbModel MapT1toT2(Customer value)
        {
            return new CustomerDbModel()
            {
                CustomerId = value.Id,
                FirstName = value.FirstName,
                FamilyName = value.FamilyName,
                Email = value.Email,
                Cellphone = value.Cellphone,
                Photo = value.Photo
            };
        }

        public override Customer MapT2toT1(CustomerDbModel value)
        {
            return new Customer()
            {
                Id = value.CustomerId,
                FirstName = value.FirstName,
                FamilyName = value.FamilyName,
                Email = value.Email,
                Cellphone = value.Cellphone,
                Photo = value.Photo
            };
        }
    }
}
