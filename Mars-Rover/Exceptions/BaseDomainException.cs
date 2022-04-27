using System;
using System.Collections.Generic;
using System.Text;

namespace Mars_Rover.Exceptions
{
    public abstract class BaseDomainException : Exception
    {
        protected BaseDomainException(string message) : base(message)
        {
        }
    }
}
