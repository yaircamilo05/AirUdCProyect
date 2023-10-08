using AirbnbUdC.Application.Contracts.Contracts.Parameters;
using AirbnbUdC.Application.Contracts.DTO.Parameters;
using AirbnbUdC.Application.Implementation.Mappers.Parameters;
using AirbnbUdC.Repository.Contracts.Contrats.Parameters;
using AirbnbUdC.Repository.Contracts.DbModel.Parameters;
using AirbnbUdC.Repository.Implementation.Implementations.Parameters;
using System.Collections.Generic;

namespace AirbnbUdC.Application.Implementation.Implementation.Parameters
{
    public class MultimediaTypeImplementationApplication : IMultimediaTypeApplication
    {
        private readonly IMultimediaTypeRepository _multimediaTypeRepository;

        public MultimediaTypeImplementationApplication()
        {
            this._multimediaTypeRepository = new MultimediaTypeImplementationRepository();
        }

        /// <summary>
        /// Metodo para crear un registro de MultimediaType en la BD
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public MultimediaTypeDto CreateRecord(MultimediaTypeDto record)
        {
            MultimediaTypeMapperApplication mapper = new MultimediaTypeMapperApplication();
            MultimediaTypeDbModel mapped = mapper.MapT2toT1(record);
            MultimediaTypeDbModel created = this._multimediaTypeRepository.CreateRecord(mapped);
            return mapper.MapT1toT2(created);
        }

        /// <summary>
        /// Metodo para eliminar un registro de MultimediaType en la bd
        /// </summary>
        /// <param name="recordId"></param>
        /// <returns></returns>
        public bool DeleteRecord(int recordId)
        {
            var deleted = this._multimediaTypeRepository.DeleteRecord(recordId);
            return deleted;
        }

        /// <summary>
        /// Metodo para obtener todos los registros de MultimediaType de la BD
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public IEnumerable<MultimediaTypeDto> GetAllRecords(string filter)
        {
            MultimediaTypeMapperApplication mapper = new MultimediaTypeMapperApplication();
            var records = this._multimediaTypeRepository.GetAllRecords(filter);
            return mapper.MapListT1toT2(records);
        }

        /// <summary>
        /// Método que obtiene un registro de la tabla MultimediaType por Id
        /// </summary>
        /// <param name="recordId"></param>
        /// <returns></returns>
        public MultimediaTypeDto GetRecord(int recordId)
        {
            MultimediaTypeMapperApplication mapper = new MultimediaTypeMapperApplication();
            MultimediaTypeDbModel record = this._multimediaTypeRepository.GetRecord(recordId);
            return mapper.MapT1toT2(record);

        }

        /// <summary>
        /// Método que actualiza un registro de la tabla MultimediaType
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public int UpdateRecord(MultimediaTypeDto record)
        {
            MultimediaTypeMapperApplication mapper = new MultimediaTypeMapperApplication();
            MultimediaTypeDbModel mapped = mapper.MapT2toT1(record);
            return this._multimediaTypeRepository.UpdateRecord(mapped);
        }
    }
}
