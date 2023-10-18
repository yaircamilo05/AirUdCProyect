using AirbnbUdC.Application.Contracts.Contracts.Manager;
using AirbnbUdC.Application.Contracts.DTO.Parameters;
using AirbnbUdC.Application.Implementation.Mappers.Manager;
using AirbnbUdC.Repository.Contracts.Contrats.Manager;
using AirbnbUdC.Repository.Contracts.DbModel.Manager;
using AirbnbUdC.Repository.Implementation.Implementations.Manager;
using System.Collections.Generic;

namespace AirbnbUdC.Application.Implementation.Implementation.Manager
{
    public class ReservationImplementationApplication : IReservationApplication
    {
        private readonly IReservationRepository _ReservationRepository;
        private readonly ReservationMapperApplication _mapper;

        public ReservationImplementationApplication()
        {
            this._ReservationRepository = new ReservationImplementationRepository();
            this._mapper = new ReservationMapperApplication();
        }

        public ReservationDto CreateRecord(ReservationDto record)
        {
            ReservationDbModel mapped = _mapper.MapT2toT1(record);
            ReservationDbModel created = this._ReservationRepository.CreateRecord(mapped);
            return _mapper.MapT1toT2(created);
        }

        public bool DeleteRecord(int recordId)
        {
            var deleted = this._ReservationRepository.DeleteRecord(recordId);
            return deleted;
        }

        public IEnumerable<ReservationDto> GetAllRecords()
        {
            var records = this._ReservationRepository.GetAllRecords();
            return _mapper.MapListT1toT2(records);
        }

        public IEnumerable<ReservationDto> GetAllRecordsByCustumerId(long custumerId)
        {
            var records = this._ReservationRepository.GetAllRecordsByCustumerId(custumerId);
            return _mapper.MapListT1toT2(records);
        }

        public IEnumerable<ReservationDto> GetAllRecordsByPropertyId(long propertyId)
        {
            var records = this._ReservationRepository.GetAllRecordsByPropertyId(propertyId);
            return _mapper.MapListT1toT2(records);
        }

        public ReservationDto GetRecord(int recordId)
        {
            ReservationDbModel record = this._ReservationRepository.GetRecord(recordId);
            return _mapper.MapT1toT2(record);

        }

        public int UpdateRecord(ReservationDto record)
        {
            ReservationDbModel mapped = _mapper.MapT2toT1(record);
            return this._ReservationRepository.UpdateRecord(mapped);
        }
    }
}
