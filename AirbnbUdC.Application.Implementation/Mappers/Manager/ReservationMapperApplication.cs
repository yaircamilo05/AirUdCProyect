﻿using AirbnbUdC.Application.Contracts.DTO.Parameters;
using AirbnbUdC.Repository.Contracts.DbModel.Manager;
using System.Collections.Generic;

namespace AirbnbUdC.Application.Implementation.Mappers.Manager
{
    public class ReservationMapperApplication : BaseMapperApplication<ReservationDbModel, ReservationDto>
    {
        public override IEnumerable<ReservationDto> MapListT1toT2(IEnumerable<ReservationDbModel> value)
        {
            foreach (var reservation in value)
            {
                yield return MapT1toT2(reservation);
            }
        }

        public override IEnumerable<ReservationDbModel> MapListT2toT1(IEnumerable<ReservationDto> value)
        {
            foreach (var reservation in value)
            {
                yield return MapT2toT1(reservation);
            }
        }

        public override ReservationDto MapT1toT2(ReservationDbModel value)
        {
            return new ReservationDto()
            {
                ReservationId = value.ReservationId,
                EnterDate = value.EnterDate,
                OutDate = value.OutDate,
                Price = value.Price,
                //property = new PropertyMapperApplication().MapT1toT2(value.property),
                //custumer = new CustumerMapperApplication().MapT1toT2(value.custumer)
              
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
                //property = new PropertyMapperApplication().MapT2toT1(value.property),
                //custumer = new CustumerMapperApplication().MapT2toT1(value.custumer)
            };
        }
    }
}
