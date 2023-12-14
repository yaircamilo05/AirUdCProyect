using AirbnbUdC.Application.Contracts.DTO.Manager;
using AirbnbUdC.Application.Contracts.DTO.Parameters;
using AirbnbUdC.Repository.Contracts.DbModel.Manager;
using System.Collections.Generic;

namespace AirbnbUdC.Application.Implementation.Mappers.Manager
{
    public class ReservationMapperApplication : BaseMapperApplication<ReservationDbModel, ReservationDto>
    {
        public override IEnumerable<ReservationDto> MapListT1toT2(IEnumerable<ReservationDbModel> value)
        {
            IList<ReservationDto> list = new List<ReservationDto>();
            foreach (var reservation in value)
            {
                list.Add(MapT1toT2(reservation));
            }
            return list;
        }

        public override IEnumerable<ReservationDbModel> MapListT2toT1(IEnumerable<ReservationDto> value)
        {
            IList<ReservationDbModel> list = new List<ReservationDbModel>();
            foreach (var reservation in value)
            {
                list.Add(MapT2toT1(reservation));
            }
            return list;
        }

        public override ReservationDto MapT1toT2(ReservationDbModel value)
        {
            return new ReservationDto()
            {
                ReservationId = value.ReservationId,
                EnterDate = value.EnterDate,
                OutDate = value.OutDate,
                Price = value.Price,
                property = new PropertyMapperApplication().MapT1toT2(value.property),
                customer = new CustomerMapperApplication().MapT1toT2(value.customer)
              
            };
        }

        public override ReservationDbModel MapT2toT1(ReservationDto value)
        {
            return new ReservationDbModel()
            {
                ReservationId = value.ReservationId,  
                EnterDate = value.EnterDate,
                OutDate = value.OutDate,
                Price = value.Price,
                property = new PropertyMapperApplication().MapT2toT1(value.property),
                customer = new CustomerMapperApplication().MapT2toT1(value.customer)
            };
        }
    }
}
