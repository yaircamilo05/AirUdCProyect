using AirbnbUdC.Application.Contracts.DTO.Manager;
using System.Collections.Generic;

namespace AirbnbUdC.Application.Contracts.Contracts.Manager
{
    public interface IFeedbackApplication
    {
        FeedbackDto CreateRecord(FeedbackDto record);
        bool DeleteRecord(int recordId);
        int UpdateRecord(FeedbackDto record);
        FeedbackDto GetRecord(int recordId);
        IEnumerable<FeedbackDto> GetAllRecords();
        IEnumerable<FeedbackDto> GetAllRecordsByReservationId(long reservationId);
        double GetAvgRateByPropertyId(long propertyId);
    }
}
