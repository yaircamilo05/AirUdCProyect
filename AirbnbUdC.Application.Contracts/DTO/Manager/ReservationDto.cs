using AirbnbUdC.Application.Contracts.DTO.Manager;
using System;

namespace AirbnbUdC.Application.Contracts.DTO.Parameters
{
    public class ReservationDto
    {
        public long ReservationId { get; set; }
        public decimal Price { get; set; }
        public DateTime EnterDate { get; set; }
        public DateTime OutDate { get; set; }
        public PropertyOwnerDto property { get; set; }
        public CustomerDto customer { get; set; }
    }
}
