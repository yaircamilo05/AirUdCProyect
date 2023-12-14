using AirbnbUdC.Application.Contracts.DTO.Manager;
using AirUdC.GUI.Models.Manager;
using System.Collections.Generic;

namespace AirUdC.GUI.Mappers.Manager
{
    public class FeedbackMapperGUI : MapperBaseGUI<FeedbackDto, FeedbackModel>
    {
        private readonly ReservationMapperGUI _reservationMapper;
        public override IEnumerable<FeedbackModel> MapListT1toT2(IEnumerable<FeedbackDto> value)
        {
            IList<FeedbackModel> list = new List<FeedbackModel>();
            foreach (var customer in value)
            {
                list.Add(MapT1toT2(customer));
            }
            return list;
        }

        public override IEnumerable<FeedbackDto> MapListT2toT1(IEnumerable<FeedbackModel> value)
        {
            IList<FeedbackDto> list = new List<FeedbackDto>();
            foreach (var customer in value)
            {
                list.Add(MapT2toT1(customer));
            }
            return list;
        }

        public override FeedbackModel MapT1toT2(FeedbackDto value)
        {
            return new FeedbackModel()
            {
                FeedbackId = value.FeedbackId,
                RateForOwner = value.RateForOwner,
                CommentsForOwner = value.CommentsForOwner,
                RateForCustomer = value.RateForCustomer,
                CommentsForCustomer = value.CommentsForCustomer,
                Reservation = _reservationMapper.MapT1toT2(value.Reservation)
            };
        }

        public override FeedbackDto MapT2toT1(FeedbackModel value)
        {
            return new FeedbackDto()
            {
               FeedbackId = value.FeedbackId,
               RateForOwner = value.RateForOwner,
               CommentsForOwner = value.CommentsForOwner,
               RateForCustomer = value.RateForCustomer,
               CommentsForCustomer = value.CommentsForCustomer,
               Reservation = _reservationMapper.MapT2toT1(value.Reservation)
            };
        }
    }
}
