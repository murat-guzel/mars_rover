using Mars_Rover.Domain.Abstract;
using Mars_Rover.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover.Domain.Concrete
{
    public class RoverCommand : ICommand
    {
        public List<Motion> CommandList { get; set; }
        public Rover rover { get; set; }
        public void ExecuteAction()
        {
            MoveRover(rover, CommandList);
        }

        public void MoveRover(Rover rover, List<Motion> commandList)
        {
            foreach (var command in commandList)
            {
                rover.Move(command);

            }
        }
    }
}
