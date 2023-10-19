using AirbnbUdC.Repository.Contracts.Contrats.Manager;
using AirbnbUdC.Repository.Contracts.DbModel.Manager;
using AirbnbUdC.Repository.Implementation.DataModel;
using AirbnbUdC.Repository.Implementation.Mappers.Manager;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Utilities.Exceptions;
using Utilities.Messages;

namespace AirbnbUdC.Repository.Implementation.Implementations.Manager
{
    public class PropertyMultimediaImplementationRepository : IPropertyMultimediaRepository
    {
        private readonly PropertyMultimediaMepperRepository _mapper;
        public PropertyMultimediaImplementationRepository()
        {
            _mapper = new PropertyMultimediaMepperRepository();
        }

        /// <summary>
        /// Metodo para guardar un registro en la BD
        /// </summary>
        /// <param name="record"></param>
        /// <returns>El registro guardado con id cuando se guarda o sin id cuando returns>
        /// <exception cref="AirException">Excepcion de la aplicacionc cuando el PropertyMultimedia ya existe en la BD</exception>
        public PropertyMultimediaDbModel CreateRecord(PropertyMultimediaDbModel record)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                var PropertyMultimedia = _mapper.MapT2toT1(record);
                var PropertyMultimediaDb = db.PropertyMultimedia.Add(PropertyMultimedia);
                db.SaveChangesAsync();
                var response = _mapper.MapT1toT2(PropertyMultimediaDb);
                return response;

            }
        }

        /// <summary>
        /// Metodo para eliminar un registro de PropertyMultimedia en la bd
        /// </summary>
        /// <param name="recordId"></param>
        /// <returns>True cuando se elimina, excepcion cuando no existe </returns>
        public bool DeleteRecord(int recordId)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                PropertyMultimedia record = db.PropertyMultimedia.FirstOrDefault(PropertyMultimedia => PropertyMultimedia.Id == recordId);

                if (record == null)
                    throw new AirException(MessagesPropertyMultimedia.PropertyMultimediaNotExists);

                else
                {
                    var response = db.PropertyMultimedia.Remove(record);

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
        /// Metodo para obtener los registros de todas las PropertyMultimedias en la base de datos 
        /// </summary>
        /// <returns>Los registros en la base de datos </returns>
        public IEnumerable<PropertyMultimediaDbModel> GetAllRecords()
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                return _mapper.MapListT1toT2(db.PropertyMultimedia);
            }
        }

        /// <summary>
        /// Metodo para obtener los registros de PropertyMultimedia en la base de datos para un Customer
        /// </summary>
        /// <returns>Los registros en la base de datos para un Custumer</returns>
        public IEnumerable<PropertyMultimediaDbModel> GetAllRecordsByPropertyId(long propertyId)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                var records = db.PropertyMultimedia.Where(PropertyMultimedia => PropertyMultimedia.PropertyId == propertyId);
                return _mapper.MapListT1toT2(records);
            }
        }

        public IEnumerable<PropertyMultimediaDbModel> GetAllRecordsByPropertyIdAndType(long propertyId, long multimediaTypeId)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                var records = db.PropertyMultimedia.Where(PropertyMultimedia => PropertyMultimedia.PropertyId == propertyId
                                                                       && PropertyMultimedia.MultimediaTypeId == multimediaTypeId);
                return _mapper.MapListT1toT2(records);
            }
        }

        /// <summary>
        /// Metodo para obtener un registro de PropertyMultimedia a partir de un Id
        /// </summary>
        /// <param name="recordId"></param>
        /// <returns>El registro correspondiente al  Id enviado</returns>
        public PropertyMultimediaDbModel GetRecord(int recordId)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                var record = db.PropertyMultimedia.Find(recordId);

                return _mapper.MapT1toT2(record);
            }
        }

        /// <summary>
        /// Metodo para actualizar un registro 
        /// </summary>
        /// <param name="record"></param>
        /// <returns>El registro actualizado</returns>
        public int UpdateRecord(PropertyMultimediaDbModel record)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {

                PropertyMultimedia dbRecord = _mapper.MapT2toT1(record);
                db.PropertyMultimedia.Attach(dbRecord);
                db.Entry(dbRecord).State = EntityState.Modified;
                return db.SaveChanges();
            }
        }
    }
}
