using AirbnbUdC.Repository.Contracts.DbModel.Manager;
using System.Collections.Generic;

namespace AirbnbUdC.Repository.Contracts.Contrats.Manager
{
    public interface IFeedbackRepository 
    {
        FeedbackDbModel CreateRecord(FeedbackDbModel record);
        bool DeleteRecord(int recordId);
        int UpdateRecord(FeedbackDbModel record);
        FeedbackDbModel GetRecord(int recordId);
        IEnumerable<FeedbackDbModel> GetAllRecords();
        IEnumerable<FeedbackDbModel> GetAllRecordsByReservationId(long propertyId);
     
    }
}
