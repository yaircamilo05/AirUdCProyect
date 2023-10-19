namespace AirbnbUdC.Repository.Contracts.DbModel.Manager
{
    public class CustomerDbModel
    {
        public long CustomerId { get; set; }
        public string FirstName { get; set; }
        public string FamilyName { get; set; }
        public string Email { get; set; }
        public string Cellphone { get; set; }
        public string Photo { get; set; }
    }
}
