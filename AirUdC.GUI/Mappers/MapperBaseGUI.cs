using System.Collections.Generic;

namespace AirUdC.GUI.Mappers
{
    public abstract class MapperBaseGUI<T1, T2>
    {
        public abstract T1 MapT2toT1(T2 value);
        public abstract T2 MapT1toT2(T1 value);
        public abstract IEnumerable<T2> MapListT1toT2(IEnumerable<T1> value);
        public abstract IEnumerable<T1> MapListT2toT1(IEnumerable<T2> value);
    }
}