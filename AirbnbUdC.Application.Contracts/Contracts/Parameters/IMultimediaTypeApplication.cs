using AirbnbUdC.Application.Contracts.DTO.Parameters;
using System.Collections.Generic;

namespace AirbnbUdC.Application.Contracts.Contracts.Parameters
{
    public interface IMultimediaTypeApplication
    {

        MultimediaTypeDto CreateRecord(MultimediaTypeDto record);
        bool DeleteRecord(int recordId);
        int UpdateRecord(MultimediaTypeDto record);
        MultimediaTypeDto GetRecord(int recordId);
        IEnumerable<MultimediaTypeDto> GetAllRecords(string filter);
    }
}
