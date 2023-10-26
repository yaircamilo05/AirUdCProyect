using AirbnbUdC.Application.Contracts.Contracts.Manager;
using AirbnbUdC.Application.Contracts.DTO.Manager;
using AirbnbUdC.Application.Implementation.Mappers.Manager;
using AirbnbUdC.Repository.Contracts.Contrats.Manager;
using AirbnbUdC.Repository.Contracts.DbModel.Manager;
using AirbnbUdC.Repository.Implementation.Implementations.Manager;
using System.Collections.Generic;

namespace AirbnbUdC.Application.Implementation.Implementation.Manager
{
    public class FeedbackImplementationApplication : IFeedbackApplication
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly FeedbackMapperApplication _mapper;
        public FeedbackImplementationApplication() {
            _feedbackRepository = new FeebackImplementationRepository();
            _mapper = new FeedbackMapperApplication();
        }
        public FeedbackDto CreateRecord(FeedbackDto record)
        {
            FeedbackDbModel mapped = _mapper.MapT2toT1(record);
            FeedbackDbModel created = this._feedbackRepository.CreateRecord(mapped);
            return _mapper.MapT1toT2(created);
        }

        public bool DeleteRecord(int recordId)
        {
            var deleted = this._feedbackRepository.DeleteRecord(recordId);
            return deleted;
        }

        public IEnumerable<FeedbackDto> GetAllRecords()
        {
            var records = this._feedbackRepository.GetAllRecords();
            return _mapper.MapListT1toT2(records);
        }

        public IEnumerable<FeedbackDto> GetAllRecordsByReservationId(long reservationId)
        {

            var records = this._feedbackRepository.GetAllRecordsByReservationId(reservationId);
            return _mapper.MapListT1toT2(records);
        }

        public FeedbackDto GetRecord(int recordId)
        {
            FeedbackDbModel record = this._feedbackRepository.GetRecord(recordId);
            return _mapper.MapT1toT2(record);

        }

        public int UpdateRecord(FeedbackDto record)
        {
            FeedbackDbModel mapped = _mapper.MapT2toT1(record);
            return this._feedbackRepository.UpdateRecord(mapped);
        }
    }
}
