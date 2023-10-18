using AirbnbUdC.Repository.Contracts.DbModel.Manager;
using AirbnbUdC.Repository.Implementation.DataModel;
using System.Collections.Generic;

namespace AirbnbUdC.Repository.Implementation.Mappers.Manager
{
    public class ReservationMapperRepository : BaseMapperRepository<Reservation, ReservationDbModel>
    {
        public override IEnumerable<ReservationDbModel> MapListT1toT2(IEnumerable<Reservation> value)
        {
            foreach (var reservation in value)
            {
                yield return MapT1toT2(reservation);
            }
        }

        public override IEnumerable<Reservation> MapListT2toT1(IEnumerable<ReservationDbModel> value)
        {
            foreach (var reservation in value)
            {
                yield return MapT2toT1(reservation);
            }
        }

        public override ReservationDbModel MapT1toT2(Reservation value)
        {
            return new ReservationDbModel()
            {
                ReservationId = value.Id,
                EnterDate = value.EnterDate,
                OutDate = value.OutDate,
                Price = value.Price,
                //property = new PropertyMapperRepository().MapT1toT2(value.property),
                //custumer = new CustumerMapperRepository().MapT1toT2(value.custumer)
            };
        }

        public override Reservation MapT2toT1(ReservationDbModel value)
        {
            return new Reservation()
            {
                Id = value.ReservationId,
                EnterDate = value.EnterDate,
                OutDate = value.OutDate,
                Price = value.Price,
                //property = new PropertyMapperRepository().MapT2toT1(value.property),
                //custumer = new CustumerMapperRepository().MapT2toT1(value.custumer)

            };
        }
    }
}
