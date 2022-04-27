using Mars_Rover.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover.Domain.Models
{
    public class Coordinate
    {
        public int X { get; set; }

        public int Y { get; set; }

        public Direction direction { get; set; }

        public Coordinate(int X, int Y, Direction direction)
        {
            this.X = X;
            this.Y = Y;
            this.direction =  direction;
        }
    }


}
