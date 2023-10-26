using AirbnbUdC.Repository.Contracts.Contrats.Manager;
using AirbnbUdC.Repository.Contracts.DbModel.Manager;
using AirbnbUdC.Repository.Implementation.DataModel;
using AirbnbUdC.Repository.Implementation.Mappers.Manager;
using AirbnbUdC.Repository.Implementation.Mappers.parameters;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Utilities.Exceptions;
using Utilities.Messages;

namespace AirbnbUdC.Repository.Implementation.Implementations.Manager
{
    public class PropertyImplementationRepository : IPropertyRepository
    {
        private readonly PropertyMapperRepository _mapper;

        public PropertyImplementationRepository()
        {
            this._mapper = new PropertyMapperRepository();
        }
        public PropertyDbModel CreateRecord(PropertyDbModel record)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                if (db.Property.Any(property => property.Latitude.Equals(record.Latitude) && property.Longitude.Equals(record.Longitude)))
                    throw new AirException(MessagesProperty.PropertyExists);

                else
                {

                    var property = this._mapper.MapT2toT1(record);
                    var propertydb = db.Property.Add(property);
                    db.SaveChanges();
                    var response = this._mapper.MapT1toT2(propertydb);
                    return response;
                }
            }
        }

        public bool DeleteRecord(int recordId)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {

                Property record = db.Property.FirstOrDefault(Property => Property.Id == recordId);

                if (record == null)
                    throw new AirException(MessagesProperty.PropertyExists);

                else
                {
                    var response = db.Property.Remove(record);

                    if (response != null)
                    {
                        db.SaveChanges();
                        return true;

                    }

                    return false;
                }
            }
        }

        public IEnumerable<PropertyDbModel> GetAllRecords(string filter)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                var records = (
                    from p in db.Property
                    //where p..Contains(filter)
                    select p
                    );
                var response = this._mapper.MapListT1toT2(records);
                return response;
            }
        }

        public IEnumerable<PropertyDbModel> GetAllRecordsByCityId(int cityId)
        {
            using(Core_DBEntities db = new Core_DBEntities())
            {
                var records = (
                    from p in db.Property
                    where p.CityId == cityId
                    select p
                    );
                var response = this._mapper.MapListT1toT2(records);
                return response;
            }
        }

        public IEnumerable<PropertyDbModel> GetAllRecordsByOwnerId(int ownerId)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                var records = (
                    from p in db.Property
                    where p.OwnerId == ownerId
                    select p
                    );
                var response = this._mapper.MapListT1toT2(records);
                return response;
            }
        }

        public PropertyDbModel GetRecord(int recordId)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                var record = db.Property.Find(recordId);
                return this._mapper.MapT1toT2(record);
            }
        }

        public int UpdateRecord(PropertyDbModel record)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                Property dbRecord = this._mapper.MapT2toT1(record);
                db.Property.Attach(dbRecord);
                db.Entry(dbRecord).State = EntityState.Modified;
                return db.SaveChanges();
            }
        }
    }
}
