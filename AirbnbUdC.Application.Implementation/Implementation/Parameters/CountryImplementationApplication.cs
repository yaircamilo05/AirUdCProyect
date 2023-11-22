using AirbnbUdC.Application.Contracts.Contracts.Parameters;
using AirbnbUdC.Application.Contracts.DTO.Parameters;
using AirbnbUdC.Application.Implementation.Mappers.Parameters;
using AirbnbUdC.Repository.Contracts.Contrats.Parameters;
using AirbnbUdC.Repository.Contracts.DbModel.Parameters;
using AirbnbUdC.Repository.Implementation.Implementations.Parameters;
using System;
using System.Collections.Generic;

namespace AirbnbUdC.Application.Implementation.Implementation.Parameters
{
    public class CountryImplementationApplication : ICountryApplication
    {

        private readonly ICountryRepository _countryRepository;

        public CountryImplementationApplication(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        /// <summary>
        /// Metodo para crear un registro en la tabla Country
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public CountryDto CreateRecord(CountryDto record)
        {
            CountryMapperApplication mapper = new CountryMapperApplication();
            CountryDbModel mapped = mapper.MapT2toT1(record);
            CountryDbModel created = this._countryRepository.CreateRecord(mapped);
            return mapper.MapT1toT2(created);
        }

        /// <summary>
        /// Metodo para eliminar un registro de la tabla Country
        /// </summary>
        /// <param name="recordId"></param>
        /// <returns></returns>
        public bool DeleteRecord(int recordId)
        {
            var deleted = this._countryRepository.DeleteRecord(recordId);
            return deleted;
        }

        /// <summary>
        /// Metodo para obtener todos los registros de la tabla Country
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public IEnumerable<CountryDto> GetAllRecords(string filter)
        {
            CountryMapperApplication mapper = new CountryMapperApplication();
            var records = this._countryRepository.GetAllRecords(filter);
            return mapper.MapListT1toT2(records);
        }

        /// <summary>
        /// Metodo para obtener un registro de la tabla Country por Id
        /// </summary>
        /// <param name="recordId"></param>
        /// <returns></returns>
        public CountryDto GetRecord(int recordId)
        {
            CountryMapperApplication mapper = new CountryMapperApplication();
            CountryDbModel record = this._countryRepository.GetRecord(recordId);
            return mapper.MapT1toT2(record);    

        }

        /// <summary>
        /// Metodo para actualizar un registro en la tabla Country
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public int UpdateRecord(CountryDto record)
        {
            CountryMapperApplication mapper = new CountryMapperApplication();
            CountryDbModel mapped = mapper.MapT2toT1(record);
            return this._countryRepository.UpdateRecord(mapped);
        }
    }
}
