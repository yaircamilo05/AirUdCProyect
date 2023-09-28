using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirbnbUdC.Application.Implementation.Mappers
{
    public abstract class BaseMapperApplication<T1, T2>
    {
        public abstract T1 MapT2toT1(T2 value);
        public abstract T2 MapT1toT2(T1 value);
        public abstract IEnumerable<T2> MapListT1toT2(IEnumerable<T1> value);
        public abstract IEnumerable<T1> MapListT2toT1(IEnumerable<T2> value);
    }
}
