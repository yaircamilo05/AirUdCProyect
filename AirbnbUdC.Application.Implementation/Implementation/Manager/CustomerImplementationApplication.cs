using AirbnbUdC.Application.Contracts.Contracts.Manager;
using AirbnbUdC.Application.Contracts.DTO.Manager;
using AirbnbUdC.Application.Implementation.Mappers.Manager;
using AirbnbUdC.Repository.Contracts.Contrats.Manager;
using AirbnbUdC.Repository.Contracts.DbModel.Manager;
using AirbnbUdC.Repository.Implementation.Implementations.Manager;
using System.Collections.Generic;

namespace AirbnbUdC.Application.Implementation.Implementation.Manager
{
    public class CustomerImplementationApplication: ICustomerApplication
    {
        
            private readonly CustomerMapperApplication _mapper;
            private readonly ICustomerRepository _CustomerRepository;
            public CustomerImplementationApplication(ICustomerRepository customerApplication)
            {
                this._mapper = new CustomerMapperApplication();
                this._CustomerRepository = customerApplication;
            }
            public CustomerDto CreateRecord(CustomerDto record)
            {
                CustomerDbModel mapped = _mapper.MapT2toT1(record);
                CustomerDbModel created = this._CustomerRepository.CreateRecord(mapped);
                return _mapper.MapT1toT2(created);
            }

            public bool DeleteRecord(int recordId)
            {
                var deleted = this._CustomerRepository.DeleteRecord(recordId);
                return deleted;
            }

            public IEnumerable<CustomerDto> GetAllRecords(string filter)
            {
                var records = this._CustomerRepository.GetAllRecords(filter);
                return _mapper.MapListT1toT2(records);
            }

            public CustomerDto GetRecord(int recordId)
            {
                CustomerDbModel record = this._CustomerRepository.GetRecord(recordId);
                return _mapper.MapT1toT2(record);
            }

            public int UpdateRecord(CustomerDto record)
            {
                CustomerDbModel mapped = _mapper.MapT2toT1(record);
                return this._CustomerRepository.UpdateRecord(mapped);
            }
        }
}
