using AirbnbUdC.Repository.Contracts.DbModel.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirbnbUdC.Repository.Contracts.Contrats.Manager
{
    public interface IPropertyRepository
    {
        PropertyDbModel CreateRecord(PropertyDbModel record);
        bool DeleteRecord(int recordId);
        int UpdateRecord(PropertyDbModel record);
        PropertyDbModel GetRecord(int recordId);
        IEnumerable<PropertyDbModel> GetAllRecords(string filter);
        IEnumerable<PropertyDbModel> GetAllRecordsByCityId(int cityId);
        IEnumerable<PropertyDbModel> GetAllRecordsByOwnerId(int ownerId);
        /**
        IEnumerable<PropertyDbModel> GetAllRecordsByPrice(decimal price);
        IEnumerable<PropertyDbModel> GetAllRecordsByPets(bool pets);
        IEnumerable<PropertyDbModel> GetAllRecordsByFreezer(bool freezer);
        IEnumerable<PropertyDbModel> GetAllRecordsByLaundryService(bool laundryService);
        IEnumerable<PropertyDbModel> GetAllRecordsByCheckInData(DateTime checkInData);
        IEnumerable<PropertyDbModel> GetAllRecordsByCheckOutData(DateTime checkOutData);
        IEnumerable<PropertyDbModel> GetAllRecordsByDetails(string details);
        IEnumerable<PropertyDbModel> GetAllRecordsByLatitude(string latitude);
        IEnumerable<PropertyDbModel> GetAllRecordsByLongitude(string longitude);
        IEnumerable<PropertyDbModel> GetAllRecordsByCustomerAmount(int customerAmount);
        **/
    }
}
