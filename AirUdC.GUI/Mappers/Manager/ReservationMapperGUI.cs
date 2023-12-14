using AirbnbUdC.Application.Contracts.DTO.Parameters;
using AirUdC.GUI.Models.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirUdC.GUI.Mappers.Manager
{
    public class ReservationMapperGUI : MapperBaseGUI<ReservationDto, ReservationModel>
    {
        private readonly PropertyMapperGUI _propertyMapper;
        private readonly CustomerMapperGUI _customerMapper;

        public ReservationMapperGUI()
        {
            _propertyMapper = new PropertyMapperGUI();
            _customerMapper = new CustomerMapperGUI();
        }
        public override IEnumerable<ReservationModel> MapListT1toT2(IEnumerable<ReservationDto> value)
        {
            IList<ReservationModel> list = new List<ReservationModel>();
            foreach (var customer in value)
            {
                list.Add(MapT1toT2(customer));
            }
            return list;
        }

        public override IEnumerable<ReservationDto> MapListT2toT1(IEnumerable<ReservationModel> value)
        {
            IList<ReservationDto> list = new List<ReservationDto>();
            foreach (var customer in value)
            {
                list.Add(MapT2toT1(customer));
            }
            return list;
        }

        public override ReservationModel MapT1toT2(ReservationDto value)
        {
            return new ReservationModel()
            {
                ReservationId = value.ReservationId,
                Price = value.Price,
                EnterDate = value.EnterDate,
                OutDate = value.OutDate,
                property = _propertyMapper.MapT1toT2(value.property),
                Customer = _customerMapper.MapT1toT2(value.customer)
            };
        }

        public override ReservationDto MapT2toT1(ReservationModel value)
        {

            return new ReservationDto()
            {
                ReservationId = value.ReservationId,
                Price = value.Price,
                EnterDate = value.EnterDate,
                OutDate = value.OutDate,
                property = _propertyMapper.MapT2toT1(value.property),
                customer = _customerMapper.MapT2toT1(value.Customer)
            };
        }
    }
}