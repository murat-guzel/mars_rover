using System;
using System.Collections.Generic;
using System.Text;

namespace Mars_Rover.Exceptions
{
    public class InvalidParameterException : BaseDomainException
    {
        public InvalidParameterException(string message) : base(message)
        {
        }
    }
}
