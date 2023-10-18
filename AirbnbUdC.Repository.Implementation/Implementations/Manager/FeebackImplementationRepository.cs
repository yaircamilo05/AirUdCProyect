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
    public class FeebackImplementationRepository : IFeedbackRepository
    {
        private readonly FeedbackMapperRepository _mapper;
        public FeebackImplementationRepository()
        {
           _mapper = new FeedbackMapperRepository();
        }

        /// <summary>
        /// Metodo para guardar un registro en la BD
        /// </summary>
        /// <param name="record"></param>
        /// <returns>El registro guardado con id cuando se guarda o sin id cuando returns>
        /// <exception cref="AirException">Excepcion de la aplicacionc cuando el Feedback ya existe en la BD</exception>
        public FeedbackDbModel CreateRecord(FeedbackDbModel record)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                var feedback = _mapper.MapT2toT1(record);
                var feedbackDb = db.Feedback.Add(feedback);
                db.SaveChangesAsync();
                var response = _mapper.MapT1toT2(feedbackDb);
                return response;
                
            }
        }

        /// <summary>
        /// Metodo para eliminar un registro de Feedback en la bd
        /// </summary>
        /// <param name="recordId"></param>
        /// <returns>True cuando se elimina, excepcion cuando no existe </returns>
        public bool DeleteRecord(int recordId)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                Feedback record = db.Feedback.FirstOrDefault(Feedback => Feedback.Id == recordId);

                if (record == null)
                    throw new AirException(MessagesFeedBack.FeedbackNotExists);

                else
                {
                    var response = db.Feedback.Remove(record);

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
        /// Metodo para obtener los registros de todas las Feedbacks en la base de datos 
        /// </summary>
        /// <returns>Los registros en la base de datos </returns>
        public IEnumerable<FeedbackDbModel> GetAllRecords()
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                return _mapper.MapListT1toT2(db.Feedback);
            }
        }

        /// <summary>
        /// Metodo para obtener los registros de Feedback en la base de datos para un Customer
        /// </summary>
        /// <returns>Los registros en la base de datos para un Custumer</returns>
        public IEnumerable<FeedbackDbModel> GetAllRecordsByReservationId(long reservationId)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                var records = db.Feedback.Where(Feedback => Feedback.ReservationId == reservationId);
                return _mapper.MapListT1toT2(records);
            }
        }

        /// <summary>
        /// Metodo para obtener un registro de Feedback a partir de un Id
        /// </summary>
        /// <param name="recordId"></param>
        /// <returns>El registro correspondiente al  Id enviado</returns>
        public FeedbackDbModel GetRecord(int recordId)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                var record = db.Feedback.Find(recordId);

                return _mapper.MapT1toT2(record);
            }
        }

        /// <summary>
        /// Metodo para actualizar un registro 
        /// </summary>
        /// <param name="record"></param>
        /// <returns>El registro actualizado</returns>
        public int UpdateRecord(FeedbackDbModel record)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {

                Feedback dbRecord = _mapper.MapT2toT1(record);
                db.Feedback.Attach(dbRecord);
                db.Entry(dbRecord).State = EntityState.Modified;
                return db.SaveChanges();
            }
        }
    }
}
