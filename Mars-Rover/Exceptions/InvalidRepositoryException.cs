using System;
using System.Collections.Generic;
using System.Text;

namespace Mars_Rover.Exceptions
{
    public class InvalidRepositoryException : BaseDomainException
    {
        public InvalidRepositoryException(string message) : base(message)
        {
        }
    }
}
