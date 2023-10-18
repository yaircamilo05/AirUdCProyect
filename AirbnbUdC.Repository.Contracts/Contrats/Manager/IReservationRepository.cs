using AirbnbUdC.Repository.Contracts.DbModel.Manager;
using System.Collections.Generic;

namespace AirbnbUdC.Repository.Contracts.Contrats.Manager
{
    public interface IReservationRepository
    {
        ReservationDbModel CreateRecord(ReservationDbModel record);
        bool DeleteRecord(int recordId);
        int UpdateRecord(ReservationDbModel record);
        ReservationDbModel GetRecord(int recordId);
        IEnumerable<ReservationDbModel> GetAllRecords();
        IEnumerable<ReservationDbModel> GetAllRecordsByPropertyId(long propertyId);
        IEnumerable<ReservationDbModel> GetAllRecordsByCustumerId(long custumerId);

    }
}
