using AirbnbUdC.Repository.Contracts.Contrats.Manager;
using AirbnbUdC.Repository.Contracts.DbModel.Manager;
using AirbnbUdC.Repository.Implementation.DataModel;
using AirbnbUdC.Repository.Implementation.Mappers.Manager;
using AirbnbUdC.Repository.Implementation.Mappers.parameters;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Utilities.Exceptions;
using Utilities.Messages;

namespace AirbnbUdC.Repository.Implementation.Implementations.Manager
{
    public class PropertyOwnerImplemetationRepository : IPropertyOwnerRepository
    {
        private readonly PropertyOwnerMapperRepository _mapper;
        public PropertyOwnerImplemetationRepository()
        {
            this._mapper = new PropertyOwnerMapperRepository();
        }
        public PropertyOwnerDbModel CreateRecord(PropertyOwnerDbModel record)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                if (db.PropertyOwner.Any(property => property.Email.Equals(record.Email)))
                {
                    throw new AirException(MessagesPropertyOwner.PropertyOwnerExists);
                }
                else
                {
                    var propertyOwner = this._mapper.MapT2toT1(record);
                    var propertyOwnerDb = db.PropertyOwner.Add(propertyOwner);
                    db.SaveChangesAsync();
                    var response = this._mapper.MapT1toT2(propertyOwnerDb);
                    return response;
                }
            }   
        }

        public bool DeleteRecord(long recordId)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {

                PropertyOwner record = db.PropertyOwner.FirstOrDefault(PropertyOwner => PropertyOwner.Id == recordId);

                if (record == null)
                    throw new AirException(MessagesPropertyOwner.PropertyOwnerNotExists);

                else
                {
                    var response = db.PropertyOwner.Remove(record);

                    if (response != null)
                    {
                        db.SaveChanges();
                        return true;

                    }

                    return false;
                }
            }
        }

        public IEnumerable<PropertyOwnerDbModel> GetAllRecords(string filters)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                var records = (
                    from p in db.PropertyOwner
                    where p.FirstName.Contains(filters)
                    select p
                    );
                var response = this._mapper.MapListT1toT2(records);
                return response;                                             
            }
        }

        public PropertyOwnerDbModel GetRecord(long recordId)
        {
            using (Core_DBEntities db = new Core_DBEntities() )
            {
                var record = db.PropertyOwner.Find(recordId);
                var response = this._mapper.MapT1toT2(record);
                return response;
            }
        }

        public int UpdateRecord(PropertyOwnerDbModel record)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                PropertyOwner dbRecord = this._mapper.MapT2toT1(record);
                db.PropertyOwner.Attach(dbRecord);
                db.Entry(dbRecord).State = EntityState.Modified;
                return db.SaveChanges();
            }
        }
    }
}
