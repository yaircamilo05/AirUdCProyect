using System;

namespace AirbnbUdC.Repository.Contracts.DbModel.Manager
{
    public class ReservationDbModel
    {
        public long ReservationId { get; set; }
        public decimal Price { get; set; }
        public DateTime EnterDate { get; set; }
        public DateTime OutDate { get; set; }
      //  public PropertyDbModel property { get; set; }
      //  public CustumerDbModel custumer { get; set; }
      
    }
}
