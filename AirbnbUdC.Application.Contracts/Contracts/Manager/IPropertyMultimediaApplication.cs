using AirbnbUdC.Application.Contracts.DTO.Manager;
using System.Collections.Generic;

namespace AirbnbUdC.Application.Contracts.Contracts.Manager
{
    public interface IPropertyMultimediaApplication
    {
        PropertyMultimediaDto CreateRecord(PropertyMultimediaDto record);
        bool DeleteRecord(int recordId);
        int UpdateRecord(PropertyMultimediaDto record);
        PropertyMultimediaDto GetRecord(int recordId);
        IEnumerable<PropertyMultimediaDto> GetAllRecords();
        IEnumerable<PropertyMultimediaDto> GetAllRecordsByPropertyId(long propertyId);
        IEnumerable<PropertyMultimediaDto> GetAllRecordsByPropertyIdAndType(long propertyId, int multimediaType);
    }
}
