using AirbnbUdC.Application.Contracts.Contracts.Manager;
using AirbnbUdC.Application.Contracts.DTO.Manager;
using AirbnbUdC.Application.Implementation.Mappers.Manager;
using AirbnbUdC.Repository.Contracts.Contrats.Manager;
using AirbnbUdC.Repository.Contracts.DbModel.Manager;
using AirbnbUdC.Repository.Implementation.Implementations.Manager;
using System.Collections.Generic;

namespace AirbnbUdC.Application.Implementation.Implementation.Manager
{
    public class PropertyOwnerImplementationApplication : IPropertyOwnerApplication
    {
        private readonly PropertyOwnerMapperApplication _mapper;
        private readonly IPropertyOwnerRepository _propertyOwnerRepository;
        public PropertyOwnerImplementationApplication()
        {
            this._mapper = new PropertyOwnerMapperApplication();
            this._propertyOwnerRepository = new PropertyOwnerImplemetationRepository();
        }
        public PropertyOwnerDto CreateRecord(PropertyOwnerDto record)
        {
            PropertyOwnerDbModel mapped = _mapper.MapT2toT1(record);
            PropertyOwnerDbModel created = this._propertyOwnerRepository.CreateRecord(mapped);
            return _mapper.MapT1toT2(created);
        }

        public bool DeleteRecord(int recordId)
        {
            var deleted = this._propertyOwnerRepository.DeleteRecord(recordId);
            return deleted;
        }

        public IEnumerable<PropertyOwnerDto> GetAllRecords(string filter)
        {
            var records = this._propertyOwnerRepository.GetAllRecords(filter);
            return _mapper.MapListT1toT2(records);
        }

        public PropertyOwnerDto GetRecord(int recordId)
        {
            PropertyOwnerDbModel record = this._propertyOwnerRepository.GetRecord(recordId);
            return _mapper.MapT1toT2(record);
        }

        public int UpdateRecord(PropertyOwnerDto record)
        {
            PropertyOwnerDbModel mapped = _mapper.MapT2toT1(record);
            return this._propertyOwnerRepository.UpdateRecord(mapped);
        }
    }
}
