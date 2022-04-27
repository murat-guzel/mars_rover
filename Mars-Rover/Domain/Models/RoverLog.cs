using Mars_Rover.Enums;
using Mars_Rover.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover.Domain.Models
{
    public class RoverLog :BaseEntity
    { 
        public LogLevel LogLevel { get; set; }

        public string Message { get; set; }
    }
}
