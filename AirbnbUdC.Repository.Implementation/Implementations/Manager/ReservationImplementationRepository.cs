using AirbnbUdC.Repository.Contracts.Contrats.Manager;
using AirbnbUdC.Repository.Contracts.DbModel.Manager;
using AirbnbUdC.Repository.Implementation.DataModel;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AirbnbUdC.Repository.Implementation.Mappers.Manager;
using Utilities.Messages;
using Utilities.Exceptions;

namespace AirbnbUdC.Repository.Implementation.Implementations.Manager
{
    public class ReservationImplementationRepository : IReservationRepository
    {
        private readonly ReservationMapperRepository  _mapper;
        public ReservationImplementationRepository()
        {
            _mapper = new ReservationMapperRepository();
        }
        /// <summary>
        /// Metodo para guardar un registro en la BD
        /// </summary>
        /// <param name="record"></param>
        /// <returns>El registro guardado con id cuando se guarda o sin id cuando returns>
        /// <exception cref="AirException">Excepcion de la aplicacionc cuando el Reservation ya existe en la BD</exception>
        public ReservationDbModel CreateRecord(ReservationDbModel record)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                //if (db.Reservation.Any(reservation => reservation.Customer.Id == record.Custumer.CustumerId && reservation.Property.PropertyId = record.Property.PropertyId)))
                //    throw new AirException(MessagesReservation.ReservationExists);
                if (false)
                    throw new AirException(MessagesReservation.ReservationExists);

                else
                {
                   
                    var reservation =  _mapper.MapT2toT1(record);
                    var reservationDB = db.Reservation.Add(reservation);
                    db.SaveChanges();
                    var response = _mapper.MapT1toT2(reservationDB);
                    return response;
                }
            }
        }

        /// <summary>
        /// Metodo para eliminar un registro de Reservation en la bd
        /// </summary>
        /// <param name="recordId"></param>
        /// <returns>True cuando se elimina, excepcion cuando no existe </returns>
        public bool DeleteRecord(int recordId)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                Reservation record = db.Reservation.FirstOrDefault(reservation => reservation.Id == recordId);

                if (record == null)
                    throw new AirException(MessagesReservation.ReservationNotExists);

                else
                {
                    var response = db.Reservation.Remove(record);

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
        /// Metodo para obtener los registros de todas las Reservations en la base de datos 
        /// </summary>
        /// <returns>Los registros en la base de datos </returns>
        public IEnumerable<ReservationDbModel> GetAllRecords()
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                
                return  _mapper.MapListT1toT2(db.Reservation);
            }
        }

        /// <summary>
        /// Metodo para obtener los registros de Reservation en la base de datos para un Customer
        /// </summary>
        /// <returns>Los registros en la base de datos para un Custumer</returns>
        public IEnumerable<ReservationDbModel> GetAllRecordsByCustumerId(long custumerId)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                var records = db.Reservation.Where(reservation => reservation.Customer.Id == custumerId);
                
                return  _mapper.MapListT1toT2(records);
            }
        }

        /// <summary>
        /// Metodo para obtener los registros de Reservation en la base de datos para una Propiedad
        /// </summary>
        /// <returns>Los registros en la base de datos parauna Propiedad</returns>
        public IEnumerable<ReservationDbModel> GetAllRecordsByPropertyId(long propertyId)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                var records = db.Reservation.Where(reservation => reservation.Property.Id == propertyId);
                
                return  _mapper.MapListT1toT2(records);
            }
        }

        /// <summary>
        /// Metodo para obtener un registro de Reservation a partir de un Id
        /// </summary>
        /// <param name="recordId"></param>
        /// <returns>El registro correspondiente al  Id enviado</returns>
        public ReservationDbModel GetRecord(int recordId)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                var record = db.Reservation.Find(recordId);
                
                return  _mapper.MapT1toT2(record);
            }
        }

        /// <summary>
        /// Metodo para actualizar un registro 
        /// </summary>
        /// <param name="record"></param>
        /// <returns>El registro actualizado</returns>
        public int UpdateRecord(ReservationDbModel record)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                
                Reservation dbRecord =  _mapper.MapT2toT1(record);
                db.Reservation.Attach(dbRecord);
                db.Entry(dbRecord).State = EntityState.Modified;
                return db.SaveChanges();
            }
        }
    }
}
