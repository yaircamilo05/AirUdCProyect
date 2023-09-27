using System.Collections.Generic;

namespace AirbnbUdC.Repository.Implementation.Mappers
{
    public abstract class BaseMapperRepository<T1, T2>
    {
        /// <summary>
        /// Mapea de T1 a t2
        /// </summary>
        /// <param name="value"> Entrada T1</param>
        /// <returns>T2</returns>
        public abstract T1 MapT2toT1(T2 value);
        public abstract T2 MapT1toT2(T1 value);
        public abstract IEnumerable<T2> MapListT1toT2(IEnumerable<T1> value);
        public abstract IEnumerable<T1> MapListT2toT1(IEnumerable<T2> value);
    }
}
