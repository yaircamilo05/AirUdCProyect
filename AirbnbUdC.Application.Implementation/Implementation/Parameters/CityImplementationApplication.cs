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
            
            /// <summary>
            /// Metodo para crear un registro de City en la BD
            /// </summary>
            /// <param name="record"></param>
            /// <returns></returns>
            public CityDto CreateRecord(CityDto record)
            {
                CityMapperApplication mapper = new CityMapperApplication();
                CityDbModel mapped = mapper.MapT2toT1(record);
                CityDbModel created = this._cityRepository.CreateRecord(mapped);
                return mapper.MapT1toT2(created);
            }
            
            /// <summary>
            /// Metodo para eliminar un registro de City en la bd
            /// </summary>
            /// <param name="recordId"></param>
            /// <returns></returns>
            public bool DeleteRecord(int recordId)
            {
                var deleted = this._cityRepository.DeleteRecord(recordId);
                return deleted;
            }
            
            /// <summary>
            /// Metodo para obtener todos los registros de City de la BD
            /// </summary>
            /// <param name="filter"></param>
            /// <returns></returns>
            public IEnumerable<CityDto> GetAllRecords(string filter)
            {
                CityMapperApplication mapper = new CityMapperApplication();
                var records = this._cityRepository.GetAllRecords(filter);
                return mapper.MapListT1toT2(records);
            }

            /// <summary>
            /// Método que obtiene un registro de la tabla City por Id
            /// </summary>
            /// <param name="recordId"></param>
            /// <returns></returns>
            public CityDto GetRecord(int recordId)
            {
                CityMapperApplication mapper = new CityMapperApplication();
                CityDbModel record = this._cityRepository.GetRecord(recordId);
                return mapper.MapT1toT2(record);

            }
            
            /// <summary>
            /// Método que actualiza un registro de la tabla City
            /// </summary>
            /// <param name="record"></param>
            /// <returns></returns>
            public int UpdateRecord(CityDto record)
            {
                CityMapperApplication mapper = new CityMapperApplication();
                CityDbModel mapped = mapper.MapT2toT1(record);
                return this._cityRepository.UpdateRecord(mapped);
            }

            /// <summary>
            /// Método que obtiene todos los registros de la tabla City por CountryId
            /// </summary>
            /// <param name="countryId"></param>
            /// <returns></returns>
            public IEnumerable<CityDto> GetAllRecordsByCountryId(int countryId)
            {
                CityMapperApplication mapper = new CityMapperApplication();
                IEnumerable<CityDbModel> records = this._cityRepository.GetAllRecordsByCountryId(countryId);
                return mapper.MapListT1toT2(records);
            }


    }
    }

