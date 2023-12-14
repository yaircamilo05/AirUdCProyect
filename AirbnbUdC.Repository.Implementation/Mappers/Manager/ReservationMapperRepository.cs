using AirbnbUdC.Repository.Contracts.DbModel.Manager;
using AirbnbUdC.Repository.Implementation.DataModel;
using System.Collections.Generic;

namespace AirbnbUdC.Repository.Implementation.Mappers.Manager
{
    public class ReservationMapperRepository : BaseMapperRepository<Reservation, ReservationDbModel>
    {
        public override IEnumerable<ReservationDbModel> MapListT1toT2(IEnumerable<Reservation> value)
        {
            IList<ReservationDbModel> list = new List<ReservationDbModel>();
            foreach (var reservation in value)
            {
                list.Add(MapT1toT2(reservation));
            }
            return list;
        }

        public override IEnumerable<Reservation> MapListT2toT1(IEnumerable<ReservationDbModel> value)
        {
            IList<Reservation> list = new List<Reservation>();
            foreach (var reservation in value)
            {
                list.Add(MapT2toT1(reservation));
            }
            return list;
        }

        public override ReservationDbModel MapT1toT2(Reservation value)
        {
            if (value == null)
            {
                return new ReservationDbModel();
            }
            return new ReservationDbModel()
            {
                ReservationId = value.Id,
                EnterDate = value.EnterDate,
                OutDate = value.OutDate,
                Price = value.Price,
                property = new PropertyMapperRepository().MapT1toT2(value.Property),
                customer = new CustomerMapperRepository().MapT1toT2(value.Customer)
            };
        }

        public override Reservation MapT2toT1(ReservationDbModel value)
        {
            if (value == null)
            {
                return new Reservation();
            }
            return new Reservation()
            {
                Id = value.ReservationId,
                EnterDate = value.EnterDate,
                OutDate = value.OutDate,
                Price = value.Price,
                PropertyId = value.property.PropertyId,
                CustomerId = value.customer.CustomerId
            };
        }
    }
}
