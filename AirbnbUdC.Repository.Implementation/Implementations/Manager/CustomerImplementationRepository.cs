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
    public class CustomerImplementationRepository: ICustomerRepository
    {
        private readonly CustomerMapperRepository _mapper;
        public CustomerImplementationRepository()
        {
            this._mapper = new CustomerMapperRepository();
        }
        public CustomerDbModel CreateRecord(CustomerDbModel record)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                if (db.Customer.Any(property => property.Email.Equals(record.Email)))
                {
                    throw new AirException(MessagesCustomer.CustomerExists);
                }
                else
                {
                    var Customer = this._mapper.MapT2toT1(record);
                    var CustomerDb = db.Customer.Add(Customer);
                    db.SaveChangesAsync();
                    var response = this._mapper.MapT1toT2(CustomerDb);
                    return response;
                }
            }
        }

        public bool DeleteRecord(long recordId)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {

                Customer record = db.Customer.FirstOrDefault(Customer => Customer.Id == recordId);

                if (record == null)
                    throw new AirException(MessagesCustomer.CustomerNotExists);

                else
                {
                    var response = db.Customer.Remove(record);

                    if (response != null)
                    {
                        db.SaveChanges();
                        return true;

                    }

                    return false;
                }
            }
        }

        public IEnumerable<CustomerDbModel> GetAllRecords(string filters)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                var records = (
                    from p in db.Customer
                    where p.FirstName.Contains(filters)
                    select p
                    );
                var response = this._mapper.MapListT1toT2(records);
                return response;
            }
        }

        public CustomerDbModel GetRecord(long recordId)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                var record = db.Customer.Find(recordId);
                var response = this._mapper.MapT1toT2(record);
                return response;
            }
        }

        public int UpdateRecord(CustomerDbModel record)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                Customer dbRecord = this._mapper.MapT2toT1(record);
                db.Customer.Attach(dbRecord);
                db.Entry(dbRecord).State = EntityState.Modified;
                return db.SaveChanges();
            }
        }
    }
}
