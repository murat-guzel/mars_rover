﻿using FluentAssertions;
using Mars_Rover.Domain.Concrete;
using Mars_Rover.Domain.Models;
using Mars_Rover.Enums;
using Mars_Rover.Exceptions;
using Mars_Rover.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Mars_Rover_Tests
{
    public class CommandTests
    {

        private readonly Mock<IRepository<RoverLog>> _roverLogRepository;


        public CommandTests()
        {
            _roverLogRepository = new Mock<IRepository<RoverLog>>();

        }


        [Fact]
        public void Given_Valid_Command_Then_Should_RightPosition()
        {

            // Arrange

            Coordinate coordinate = new Coordinate(1, 2, Direction.N);
            var plateau = new Plateau();

            plateau.Height = 5;
            plateau.Width = 5;

            var rover = new Rover(coordinate, plateau, _roverLogRepository.Object);
            List<Motion> motionList = new List<Motion>();
            RoverCommand roverCommand = new RoverCommand();
            roverCommand.CommandList = new List<Motion>();

            motionList.Add(Motion.TurnLeft);
            motionList.Add(Motion.Move);
            motionList.Add(Motion.TurnLeft);
            motionList.Add(Motion.Move);
            motionList.Add(Motion.TurnLeft);
            motionList.Add(Motion.Move);
            motionList.Add(Motion.TurnLeft);
            motionList.Add(Motion.Move);
            motionList.Add(Motion.Move);

            roverCommand.CommandList = motionList;
            roverCommand.rover = rover;
            roverCommand.ExecuteAction();

            // Act

            int actX = 1;
            int actY = 3;
            Direction actDirection = Direction.N;

            // Assert
            rover.X.Should().Be(actX);
            rover.Y.Should().Be(actY);
            rover.direction.Should().Be(actDirection);

        }

        [Fact]
        public void Given_Valid_CommandEast_Then_Should_RightPosition()
        {

            // Arrange

            Coordinate coordinate = new Coordinate(3, 3, Direction.E);
            var plateau = new Plateau();

            plateau.Height = 5;
            plateau.Width = 5;

            var rover = new Rover(coordinate, plateau, _roverLogRepository.Object);
            List<Motion> motionList = new List<Motion>();
            RoverCommand roverCommand = new RoverCommand();
            roverCommand.CommandList = new List<Motion>();

            motionList.Add(Motion.Move);
            motionList.Add(Motion.Move);
            motionList.Add(Motion.TurnRight);
            motionList.Add(Motion.Move);
            motionList.Add(Motion.Move);
            motionList.Add(Motion.TurnRight);
            motionList.Add(Motion.Move);
            motionList.Add(Motion.TurnRight);
            motionList.Add(Motion.TurnRight);
            motionList.Add(Motion.Move);

            roverCommand.CommandList = motionList;
            roverCommand.rover = rover;
            roverCommand.ExecuteAction();

            // Act

            int actX = 5;
            int actY = 1;
            Direction actDirection = Direction.E;

            // Assert
            rover.X.Should().Be(actX);
            rover.Y.Should().Be(actY);
            rover.direction.Should().Be(actDirection);

        }
        [Fact]
        public void Given_Valid_Command_Then_Should_OutOfPlateau()
        {

            // Arrange

            Coordinate coordinate = new Coordinate(3, 3, Direction.E);
            var plateau = new Plateau();

            plateau.Height = 5;
            plateau.Width = 5;

            var rover = new Rover(coordinate, plateau, _roverLogRepository.Object);
            List<Motion> motionList = new List<Motion>();
            RoverCommand roverCommand = new RoverCommand();
            roverCommand.CommandList = new List<Motion>();

            motionList.Add(Motion.Move);
            motionList.Add(Motion.Move);
            motionList.Add(Motion.Move);
            motionList.Add(Motion.Move);
            motionList.Add(Motion.Move);
            motionList.Add(Motion.Move);
            motionList.Add(Motion.Move);
            motionList.Add(Motion.Move);
            motionList.Add(Motion.Move);
            motionList.Add(Motion.Move);

            roverCommand.CommandList = motionList;
            roverCommand.rover = rover;

            // Act

            bool act = true;

            // Assert
               

            Assert.Throws<InvalidBusinessException>(() =>
            {
                roverCommand.ExecuteAction();
            });

        }
    }
}
