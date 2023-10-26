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
            IList<FeedbackDto> list = new List<FeedbackDto>();
            foreach (var feedback in value)
            {
                list.Add(MapT1toT2(feedback));
            }
            return list;
        }

        public override IEnumerable<FeedbackDbModel> MapListT2toT1(IEnumerable<FeedbackDto> value)
        {
            IList<FeedbackDbModel> list = new List<FeedbackDbModel>();
            foreach (var feedback in value)
            {
                list.Add(MapT2toT1(feedback));
            }
            return list;
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

