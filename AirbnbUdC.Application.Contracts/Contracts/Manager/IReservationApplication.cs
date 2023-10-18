using AirbnbUdC.Application.Contracts.DTO.Parameters;
using System.Collections.Generic;

namespace AirbnbUdC.Application.Contracts.Contracts.Manager
{
    public interface IReservationApplication
    {
        ReservationDto CreateRecord(ReservationDto record);
        bool DeleteRecord(int recordId);
        int UpdateRecord(ReservationDto record);
        ReservationDto GetRecord(int recordId);
        IEnumerable<ReservationDto> GetAllRecords();
        IEnumerable<ReservationDto> GetAllRecordsByPropertyId(long propertyId);
        IEnumerable<ReservationDto> GetAllRecordsByCustumerId(long custumerId);
    }
}
