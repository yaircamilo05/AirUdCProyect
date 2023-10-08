using AirbnbUdC.Repository.Contracts.Contrats.Parameters;
using AirbnbUdC.Repository.Contracts.DbModel.Parameters;
using AirbnbUdC.Repository.Implementation.DataModel;
using AirbnbUdC.Repository.Implementation.Mappers.Parameters;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Utilities.Exceptions;
using Utilities.Messages;

namespace AirbnbUdC.Repository.Implementation.Implementations.Parameters
{
    public class MultimediaTypeImplementationRepository : IMultimediaTypeRepository
    {
        /// <summary>
        /// Metodo para guardar un registro de MultimediaType en la BD
        /// </summary>
        /// <param name="record"></param>
        /// <returns>El registro guardado con id cuando se guarda o excepcion returns>
        /// <exception cref="AirException">Excepcion de la aplicacionc cuando la MultimediaType ya existe en la BD</exception>
        public MultimediaTypeDbModel CreateRecord(MultimediaTypeDbModel record)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                if (db.MultimediaType.Any(MultimediaType => MultimediaType.MultimediaTypeName.Equals(record.MultimediaTypeName)))
                    throw new AirException(MessagesMultimediaType.MultimediaTypeExists);

                else
                {
                    MultimediaTypeMapperRepository multimediaTypeMapperRepository = new MultimediaTypeMapperRepository();
                    var multimediaType = multimediaTypeMapperRepository.MapT2toT1(record);
                    var multimediaTypeDb = db.MultimediaType.Add(multimediaType);
                    db.SaveChanges();
                    var response = multimediaTypeMapperRepository.MapT1toT2(multimediaTypeDb);
                    return response;
                }
            }
        }

        /// <summary>
        /// Metodo para eliminar un registro de MultimediaType en la bd
        /// </summary>
        /// <param name="recordId"></param>
        /// <returns>True cuando se elimina, excepcion cuando no existe </returns>
        public bool DeleteRecord(int recordId)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                MultimediaType record = db.MultimediaType.FirstOrDefault(MultimediaType => MultimediaType.Id == recordId);

                if (record == null)
                    throw new AirException(MessagesMultimediaType.MultimediaTypeNotExists);

                else
                {
                    var response = db.MultimediaType.Remove(record);

                    if (response != null)
                    {
                        db.SaveChanges();
                        return true;

                    }

                    return false;
                }
            }
        }

        /// <summary>
        /// Metodo para obtener los registros de MultimediaType en la base de datos
        /// </summary>
        /// <returns>Los registros en la base de datos</returns>
        public IEnumerable<MultimediaTypeDbModel> GetAllRecords(string filter)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                var records = (
                    from mt in db.MultimediaType
                    where mt.MultimediaTypeName.Contains(filter)
                    select mt
                    );
                MultimediaTypeMapperRepository mapper = new MultimediaTypeMapperRepository();

                return mapper.MapListT1toT2(records);
            }
        }

        /// <summary>
        /// Metodo para obtener un registro de MultimediaType a partir de un Id
        /// </summary>
        /// <param name="recordId"></param>
        /// <returns>El registro correspondiente al  Id enviado</returns>
        public MultimediaTypeDbModel GetRecord(int recordId)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                var record = db.MultimediaType.Find(recordId);
                MultimediaTypeMapperRepository mapper = new MultimediaTypeMapperRepository();

                if (record != null)
                {
                    return mapper.MapT1toT2(record);
                } 
                
                throw new AirException(MessagesMultimediaType.MultimediaTypeNotExists);
            }

        }

        /// <summary>
        /// Metodo para actualizar un registro 
        /// </summary>
        /// <param name="record"></param>
        /// <returns>El registro actualizado</returns>
        public int UpdateRecord(MultimediaTypeDbModel record)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                MultimediaTypeMapperRepository mapper = new MultimediaTypeMapperRepository();
                MultimediaType dbRecord = mapper.MapT2toT1(record);
                db.MultimediaType.Attach(dbRecord);
                db.Entry(dbRecord).State = EntityState.Modified;
                return db.SaveChanges();
            }
        }
    }
}
