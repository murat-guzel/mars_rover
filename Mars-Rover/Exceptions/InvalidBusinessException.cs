using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover.Exceptions
{
    public class InvalidBusinessException : BaseDomainException
    {
        public InvalidBusinessException(string message) : base(message)
        {
        }
    }
}
