using AirbnbUdC.Application.Contracts.Contracts.Parameters;
using AirbnbUdC.Application.Contracts.DTO.Parameters;
using AirbnbUdC.Application.Implementation.Mappers.Parameters;
using AirbnbUdC.Repository.Contracts.Contrats.Parameters;
using AirbnbUdC.Repository.Contracts.DbModel.Parameters;
using AirbnbUdC.Repository.Implementation.Implementations.Parameters;
using System.Collections.Generic;

namespace AirbnbUdC.Application.Implementation.Implementation.Parameters
{
        public class CityImplementationApplication : ICityApplication
        {

            private readonly ICityRepository _cityRepository;

            public CityImplementationApplication()
            {
                this._cityRepository = new CityImplementationRepository();
            }

            public CityDto CreateRecord(CityDto record)
            {
                CityMapperApplication mapper = new CityMapperApplication();
                CityDbModel mapped = mapper.MapT2toT1(record);
                CityDbModel created = this._cityRepository.CreateRecord(mapped);
                return mapper.MapT1toT2(created);
            }

            public bool DeleteRecord(int recordId)
            {
                var deleted = this._cityRepository.DeleteRecord(recordId);
                return deleted;
            }

            public IEnumerable<CityDto> GetAllRecords(string filter)
            {
                CityMapperApplication mapper = new CityMapperApplication();
                var records = this._cityRepository.GetAllRecords(filter);
                return mapper.MapListT1toT2(records);
            }

            public CityDto GetRecord(int recordId)
            {
                CityMapperApplication mapper = new CityMapperApplication();
                CityDbModel record = this._cityRepository.GetRecord(recordId);
                return mapper.MapT1toT2(record);

            }

            public int UpdateRecord(CityDto record)
            {
                CityMapperApplication mapper = new CityMapperApplication();
                CityDbModel mapped = mapper.MapT2toT1(record);
                return this._cityRepository.UpdateRecord(mapped);
            }
        }
    }

