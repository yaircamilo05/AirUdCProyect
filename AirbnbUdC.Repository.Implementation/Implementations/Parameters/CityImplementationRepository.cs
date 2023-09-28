using AirbnbUdC.Repository.Contracts.Contrats.Parameters;
using AirbnbUdC.Repository.Contracts.DbModel.Parameters;
using AirbnbUdC.Repository.Implementation.DataModel;
using AirbnbUdC.Repository.Implementation.Mappers.parameters;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Utilities.Exceptions;
using Utilities.Messages;

namespace AirbnbUdC.Repository.Implementation.Implementations.Parameters
{
    public class CityImplementationRepository : ICityRepository
    {
        /// <summary>
        /// Metodo para guardar un registro en la BD
        /// </summary>
        /// <param name="record"></param>
        /// <returns>El registro guardado con id cuando se guarda o sin id cuando returns>
        /// <exception cref="AirException">Excepcion de la aplicacionc cuando el City ya existe en la BD</exception>
        public CityDbModel CreateRecord(CityDbModel record)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                if (db.City.Any(country => country.CityName.Equals(record.CityName)))
                    throw new AirException(MessagesCity.CityExists);

                else
                {
                    CityMapperRepository countryMapperRepository = new CityMapperRepository();
                    var country = countryMapperRepository.MapT2toT1(record);
                    var countryDb = db.City.Add(country);
                    db.SaveChangesAsync();
                    var response = countryMapperRepository.MapT1toT2(countryDb);
                    return response;
                }
            }
        }

        /// <summary>
        /// Metodo para eliminar un registro de City en la bd
        /// </summary>
        /// <param name="recordId"></param>
        /// <returns>True cuando se elimina, excepcion cuando no existe </returns>
        public bool DeleteRecord(int recordId)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                City record = db.City.FirstOrDefault(city => city.Id == recordId);

                if (record == null)
                    throw new AirException(MessagesCity.CityNotExists);

                else
                {
                    var response = db.City.Remove(record);

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
        /// Metodo para obtener los registros de City en la base de datos
        /// </summary>
        /// <returns>Los registros en la base de datos</returns>
        public IEnumerable<CityDbModel> GetAllRecords(string filter)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                var records = (
                    from c in db.City
                    where c.CityName.Contains(filter)
                    select c
                    );
                CityMapperRepository mapper = new CityMapperRepository();

                return mapper.MapListT1toT2(records);
            }
        }

        /// <summary>
        /// Metodo para obtener un registro de City a partir de un Id
        /// </summary>
        /// <param name="recordId"></param>
        /// <returns>El registro correspondiente al  Id enviado</returns>
        public CityDbModel GetRecord(int recordId)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                var record = db.City.Find(recordId);
                CityMapperRepository mapper = new CityMapperRepository();
                return mapper.MapT1toT2(record);
            }
        }

        /// <summary>
        /// Metodo para actualizar un registro 
        /// </summary>
        /// <param name="record"></param>
        /// <returns>El registro actualizado</returns>
        public int UpdateRecord(CityDbModel record)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                CityMapperRepository mapper = new CityMapperRepository();
                City dbRecord = mapper.MapT2toT1(record);
                db.City.Attach(dbRecord);
                db.Entry(dbRecord).State = EntityState.Modified;
                return db.SaveChanges();
            }
        }
    }
}
