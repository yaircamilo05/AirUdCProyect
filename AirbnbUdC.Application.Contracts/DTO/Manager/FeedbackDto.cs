using AirbnbUdC.Application.Contracts.DTO.Parameters;

namespace AirbnbUdC.Application.Contracts.DTO.Manager
{
    public class FeedbackDto
    {
        public long FeedbackId { get; set; }
        public int? RateForOwner { get; set; }
        public string CommentsForOwner { get; set; }
        public int? RateForCustomer { get; set; }
        public string CommentsForCustomer { get; set; }
        public ReservationDto Reservation { get; set; }
    }
}
