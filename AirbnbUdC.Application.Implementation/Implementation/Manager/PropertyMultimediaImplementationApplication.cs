using AirbnbUdC.Application.Contracts.Contracts.Manager;
using AirbnbUdC.Application.Contracts.DTO.Manager;
using AirbnbUdC.Application.Implementation.Mappers.Manager;
using AirbnbUdC.Repository.Contracts.Contrats.Manager;
using AirbnbUdC.Repository.Contracts.DbModel.Manager;
using AirbnbUdC.Repository.Implementation.Implementations.Manager;
using System.Collections.Generic;

namespace AirbnbUdC.Application.Implementation.Implementation.Manager
{
    public class PropertyMultimediaImplementationApplication : IPropertyMultimediaApplication
    {
        private readonly IPropertyMultimediaRepository _propertyMultimediaRepository;
        private readonly PropertyMultimediaMapperApplication _mapper;
        public PropertyMultimediaImplementationApplication()
        {
            _propertyMultimediaRepository = new PropertyMultimediaImplementationRepository();
            _mapper = new PropertyMultimediaMapperApplication();
        }
        public PropertyMultimediaDto CreateRecord(PropertyMultimediaDto record)
        {
            PropertyMultimediaDbModel mapped = _mapper.MapT2toT1(record);
            PropertyMultimediaDbModel created = this._propertyMultimediaRepository.CreateRecord(mapped);
            return _mapper.MapT1toT2(created);
        }

        public bool DeleteRecord(int recordId)
        {
            var deleted = this._propertyMultimediaRepository.DeleteRecord(recordId);
            return deleted;
        }

        public IEnumerable<PropertyMultimediaDto> GetAllRecords()
        {
            var records = this._propertyMultimediaRepository.GetAllRecords();
            return _mapper.MapListT1toT2(records);
        }

        public IEnumerable<PropertyMultimediaDto> GetAllRecordsByPropertyId(long propertyId)
        {
            var records = this._propertyMultimediaRepository.GetAllRecordsByPropertyId(propertyId);
            return _mapper.MapListT1toT2(records);
        }

        public IEnumerable<PropertyMultimediaDto> GetAllRecordsByPropertyIdAndType(long propertyId, int multimediaType)
        {
            var records = this._propertyMultimediaRepository.GetAllRecordsByPropertyIdAndType(propertyId, multimediaType);
            return _mapper.MapListT1toT2(records);
        }

        public PropertyMultimediaDto GetRecord(int recordId)
        {
            PropertyMultimediaDbModel record = this._propertyMultimediaRepository.GetRecord(recordId);
            return _mapper.MapT1toT2(record);

        }

        public int UpdateRecord(PropertyMultimediaDto record)
        {
            PropertyMultimediaDbModel mapped = _mapper.MapT2toT1(record);
            return this._propertyMultimediaRepository.UpdateRecord(mapped);
        }
    }
}
