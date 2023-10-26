using AirbnbUdC.Application.Contracts.Contracts.Manager;
using AirbnbUdC.Application.Contracts.DTO.Manager;
using AirbnbUdC.Application.Implementation.Mappers.Manager;
using AirbnbUdC.Repository.Contracts.Contrats.Manager;
using AirbnbUdC.Repository.Contracts.DbModel.Manager;
using AirbnbUdC.Repository.Implementation.Implementations.Manager;
using System.Collections.Generic;

namespace AirbnbUdC.Application.Implementation.Implementation.Manager
{
    public class PropertyImplementationApplication : IPropertyApplication
    {
        private readonly PropertyMapperApplication _mapper;
        private readonly IPropertyRepository _propertyRepository;
        public PropertyImplementationApplication()
        {
            this._mapper = new PropertyMapperApplication();
            this._propertyRepository = new PropertyImplementationRepository();
        }

        public PropertyDto CreateRecord(PropertyDto record)
        {
            PropertyDbModel mapped = _mapper.MapT2toT1(record);
            PropertyDbModel created = this._propertyRepository.CreateRecord(mapped);
            return _mapper.MapT1toT2(created);
        }

        public bool DeleteRecord(int recordId)
        {
            var deleted = this._propertyRepository.DeleteRecord(recordId);
            return deleted;
        }

        public IEnumerable<PropertyDto> GetAllRecordsByCityId(int CityId)
        {
            IEnumerable<PropertyDbModel> records = this._propertyRepository.GetAllRecordsByCityId(CityId);
            return _mapper.MapListT1toT2(records);
        }

        public IEnumerable<PropertyDto> GetAllRecordsByPropertyOwnerId(int PropertyOwnerId)
        {
            IEnumerable<PropertyDbModel> records = this._propertyRepository.GetAllRecordsByOwnerId(PropertyOwnerId);
            return _mapper.MapListT1toT2(records);
        }

        public PropertyDto GetRecord(int recordId)
        {
            PropertyDbModel record = this._propertyRepository.GetRecord(recordId);
            return _mapper.MapT1toT2(record);
        }

        public IEnumerable<PropertyDto> GetAllRecords(string filter)
        {
            IEnumerable<PropertyDbModel> records = this._propertyRepository.GetAllRecords(filter);
            return _mapper.MapListT1toT2(records);
            
        }

        public int UpdateRecord(PropertyDto record)
        {
            PropertyDbModel mapped = _mapper.MapT2toT1(record);
            return this._propertyRepository.UpdateRecord(mapped);
        }
    }
}
