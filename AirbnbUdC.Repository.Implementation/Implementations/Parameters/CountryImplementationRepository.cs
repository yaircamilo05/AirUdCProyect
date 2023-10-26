using AirbnbUdC.Repository.Contracts.Contrats.Parameters;
using AirbnbUdC.Repository.Contracts.DbModel.Parameters;
using AirbnbUdC.Repository.Implementation.DataModel;
using AirbnbUdC.Repository.Implementation.Mappers.parameters;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using Utilities.Exceptions;
using Utilities.Messages;

namespace AirbnbUdC.Repository.Implementation.Implementations.Parameters
{
    public class CountryImplementationRepository : ICountryRepository
    {   
        /// <summary>
        /// Metodo para guardar un registro en la BD
        /// </summary>
        /// <param name="record"></param>
        /// <returns>El registro guardado con id cuando se guarda o sin id cuando returns>
        /// <exception cref="AirException">Excepcion de la aplicacionc cuando el Country ya existe en la BD</exception>
        public CountryDbModel CreateRecord(CountryDbModel record)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                if (db.Country.Any(country => country.CountryName.Equals(record.CountryName)))
                    throw new AirException(MessagesCountry.CountryExists);
                
                else
                {
                    CountryMapperRepository countryMapperRepository = new CountryMapperRepository();
                    var country = countryMapperRepository.MapT2toT1(record);
                    var countryDb = db.Country.Add(country);
                    db.SaveChanges();
                    var response = countryMapperRepository.MapT1toT2(countryDb);
                    return response;
                }
            }
        }

        /// <summary>
        /// Metodo para eliminar un registro de Country en la bd
        /// </summary>
        /// <param name="recordId"></param>
        /// <returns>1 cuando se elimina, 0 cuando no existe o excepcion</returns>
        public bool DeleteRecord(int recordId)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {

                Country record = db.Country.FirstOrDefault(country => country.Id == recordId);

                if (record == null)
                    throw new AirException(MessagesCountry.CountryNotExists);

                else
                {
                    var response = db.Country.Remove(record);

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
        /// Metodo para obtener los registros de Country en la base de datos
        /// </summary>
        /// <returns>Los registros en la base de datos</returns>
        public IEnumerable<CountryDbModel> GetAllRecords(string filter)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                var records = (
                    from c in db.Country
                    where c.CountryName.Contains(filter)
                    select c
                    );
                CountryMapperRepository mapper = new CountryMapperRepository();
                
                return mapper.MapListT1toT2(records);
            }
        }

        /// <summary>
        /// Metodo para obtener un registro de Country a partir de un Id
        /// </summary>
        /// <param name="recordId"></param>
        /// <returns>El registro correspondiente al  Id enviado</returns>
        public CountryDbModel GetRecord(int recordId)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                var record = db.Country.Find(recordId);
                CountryMapperRepository mapper = new CountryMapperRepository();
                return mapper.MapT1toT2(record);
            }
        }

        /// <summary>
        /// Metodo para actualizar un registro 
        /// </summary>
        /// <param name="record"></param>
        /// <returns>El registro actualizado</returns>
        public int UpdateRecord(CountryDbModel record)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                CountryMapperRepository mapper = new CountryMapperRepository();
                Country dbRecord = mapper.MapT2toT1(record);
                db.Country.Attach(dbRecord);
                db.Entry(dbRecord).State = EntityState.Modified;
                return db.SaveChanges();
            }
        }
    }
}
