using Mars_Rover.Domain.Abstract;
using Mars_Rover.Domain.Models;
using Mars_Rover.Enums;
using Mars_Rover.Exceptions;
using Mars_Rover.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover.Domain.Concrete
{
    public class Rover
    {
        private readonly IRepository<RoverLog> _roverlogRepository;
        public Direction direction { get; set; }
        public Coordinate coordinate { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Plateau plateau { get; set; }




        public Rover(Coordinate coordinate, Plateau plateau, IRepository<RoverLog> roverlogRepository)
        {
            this.X = coordinate.X;
            this.Y = coordinate.Y;
            this.coordinate = coordinate;
            direction = coordinate.direction;
            this.plateau = plateau;
            _roverlogRepository = roverlogRepository;
        }

        public void TurnLeft()
        {
            switch (this.direction)
            {
                case Direction.N:
                    this.direction = Direction.W;
                    break;
                case Direction.E:
                    this.direction = Direction.N;
                    break;
                case Direction.W:
                    this.direction = Direction.S;
                    break;
                case Direction.S:
                    this.direction = Direction.E;
                    break;
            }



        }
        public void TurnRight()
        {
            switch (this.direction)
            {
                case Direction.N:
                    this.direction = Direction.E;
                    break;
                case Direction.E:
                    this.direction = Direction.S;
                    break;
                case Direction.W:
                    this.direction = Direction.N;
                    break;
                case Direction.S:
                    this.direction = Direction.W;
                    break;
            }
        }

        public void MoveStraight()
        {
            if (this.direction == Direction.N)
                this.Y += 1;
            if (this.direction == Direction.E)
                this.X += 1;
            if (this.direction == Direction.W)
                this.X -= 1;
            if (this.direction == Direction.S)
                this.Y -= 1;

            if (IsInPlateau())
            {
                try
                {
                    _roverlogRepository.Add(new RoverLog()
                    {
                        LogLevel = LogLevel.Error,
                        Message = "Rover is out of the Plateau"
                    });

                }
                catch (Exception)
                {

                    throw new InvalidRepositoryException("Postgresql is not connected");

                }
                throw new InvalidBusinessException("Rover is out of the Plateau");
            }
        }

        public bool IsInPlateau()
        {
            return this.X < 0 || this.X > plateau.Width || this.Y < 0 || this.Y > plateau.Height;
           
        }
        public void Move(Motion motion)
        {

            switch (motion)
            {
                case Motion.TurnLeft:
                    TurnLeft();
                    break;
                case Motion.TurnRight:
                    TurnRight();
                    break;
                case Motion.Move:
                    MoveStraight();
                    break;
                default:
                    break;
            }

        }



    }
}
