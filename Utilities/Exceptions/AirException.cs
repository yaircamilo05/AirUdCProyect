using System;

namespace Utilities.Exceptions
{
    public class AirException : Exception
    {
        public AirException(string message):base(message) { 
        }
    }
}
