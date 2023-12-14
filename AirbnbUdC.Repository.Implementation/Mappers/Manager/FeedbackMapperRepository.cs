using AirbnbUdC.Repository.Contracts.DbModel.Manager;
using AirbnbUdC.Repository.Implementation.DataModel;
using System.Collections.Generic;

namespace AirbnbUdC.Repository.Implementation.Mappers.Manager
{
    public class FeedbackMapperRepository : BaseMapperRepository<Feedback, FeedbackDbModel>
    {
        private readonly ReservationMapperRepository _reservationMapper;
        public FeedbackMapperRepository() {
            _reservationMapper = new ReservationMapperRepository();
        }
        public override IEnumerable<FeedbackDbModel> MapListT1toT2(IEnumerable<Feedback> value)
        {
            IList<FeedbackDbModel> list = new List<FeedbackDbModel>();
            foreach (var feedback in value)
            {
                list.Add(MapT1toT2(feedback));
            }
            return list;
        }

        public override IEnumerable<Feedback> MapListT2toT1(IEnumerable<FeedbackDbModel> value)
        {
            IList<Feedback> list = new List<Feedback>();
            foreach (var feedback in value)
            {
                list.Add(MapT2toT1(feedback));
            }
            return list;
        }

        public override FeedbackDbModel MapT1toT2(Feedback value)
        {
            return new FeedbackDbModel()
            {
                FeedbackId = value.Id,
                RateForCustomer = value.RateForCustomer,
                CommentsForCustomer = value.CommentsForCustomer,
                RateForOwner = value.RateForOwner,
                CommentsForOwner = value.CommentsForOwner,
                Reservation = _reservationMapper.MapT1toT2(value.Reservation)
            };
        }

        public override Feedback MapT2toT1(FeedbackDbModel value)
        {
            return new Feedback()
            {
               Id = value.FeedbackId,
               RateForCustomer = value.RateForCustomer,
               CommentsForCustomer = value.CommentsForCustomer,
               RateForOwner = value.RateForOwner,
               CommentsForOwner = value.CommentsForOwner,
                ReservationId = value.Reservation.ReservationId
            };
        }
    }
}
