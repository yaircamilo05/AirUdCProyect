using AirbnbUdC.Application.Contracts.DTO.Manager;
using AirbnbUdC.Repository.Contracts.DbModel.Manager;
using System.Collections.Generic;

namespace AirbnbUdC.Application.Implementation.Mappers.Manager
{
    public class FeedbackMapperApplication : BaseMapperApplication<FeedbackDbModel, FeedbackDto>
    {
        private readonly ReservationMapperApplication _reservationMapper;
        public FeedbackMapperApplication() {
            _reservationMapper = new ReservationMapperApplication();
        }
        public override IEnumerable<FeedbackDto> MapListT1toT2(IEnumerable<FeedbackDbModel> value)
        {
            foreach (var Feedback in value)
            {
                yield return MapT1toT2(Feedback);
            }
        }

        public override IEnumerable<FeedbackDbModel> MapListT2toT1(IEnumerable<FeedbackDto> value)
        {
            foreach (var Feedback in value)
            {
                yield return MapT2toT1(Feedback);
            }
        }

        public override FeedbackDto MapT1toT2(FeedbackDbModel value)
        {
            return new FeedbackDto()
            {
                  FeedbackId = value.FeedbackId,
                  RateForCustomer = value.RateForCustomer,
                  CommentsForCustomer = value.CommentsForCustomer,
                  RateForOwner = value.RateForOwner,
                  CommentsForOwner = value.CommentsForOwner,
                  Reservation = _reservationMapper.MapT1toT2(value.Reservation)


            };
        }

        public override FeedbackDbModel MapT2toT1(FeedbackDto value)
        {
            return new FeedbackDbModel()
            {
               FeedbackId = value.FeedbackId,
               RateForCustomer = value.RateForCustomer,
               CommentsForCustomer = value.CommentsForCustomer,
               RateForOwner = value.RateForOwner,
               CommentsForOwner = value.CommentsForOwner,
               Reservation = _reservationMapper.MapT2toT1(value.Reservation)
            };
        }
    }
}

