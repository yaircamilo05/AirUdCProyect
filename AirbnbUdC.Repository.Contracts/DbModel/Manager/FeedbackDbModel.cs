namespace AirbnbUdC.Repository.Contracts.DbModel.Manager
{
    public class FeedbackDbModel
    {
        public long FeedbackId { get; set; }
        public int? RateForOwner { get; set; }
        public string CommentsForOwner { get; set; }
        public int? RateForCustomer { get; set; }
        public string CommentsForCustomer { get; set; }
        public ReservationDbModel Reservation { get; set; }
    }
}
