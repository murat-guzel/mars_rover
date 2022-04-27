using FluentAssertions;
using Mars_Rover.Domain.Concrete;
using Mars_Rover.Domain.Models;
using Mars_Rover.Enums;
using Mars_Rover.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Mars_Rover_Tests.IntegrationTests
{
    public class BaseIntegrationTest 
    {
        private readonly Mock<IRepository<RoverLog>> _roverLogRepository;


        public BaseIntegrationTest()
        {
            _roverLogRepository = new Mock<IRepository<RoverLog>>();

        }

        [Fact]
        public void Given_Valid_Request_Then_Should_Rover()
        {

            // Arrange
            Coordinate coordinate = new Coordinate(1, 2, Direction.N);
            var plateau = new Plateau();

            plateau.Height = 5;
            plateau.Width = 5;

            var rover = new Rover(coordinate, plateau, _roverLogRepository.Object);
             

            // Act

            int roverCoordinateX = 1;
            int roverCoordinateY = 2;
            Direction actDirection = Direction.N;

            // Assert
            rover.X.Should().Be(roverCoordinateX);
            rover.Y.Should().Be(roverCoordinateY);
            rover.direction.Should().Be(actDirection);

        }

        [Fact]
        public void Given_Valid_Request_Then_Should_WrongRover()
        {

            // Arrange
            Coordinate coordinate = new Coordinate(1, 2, Direction.N);
            var plateau = new Plateau();

            plateau.Height = 5;
            plateau.Width = 5;

            var rover = new Rover(coordinate, plateau, _roverLogRepository.Object);


            // Act

            int roverCoordinateX = 1; 
            Direction actDirection = Direction.N;

            // Assert
            rover.X.Should().Be(roverCoordinateX);
            rover.Y.Should().NotBe(roverCoordinateX);
            rover.direction.Should().Be(actDirection);

        }

    }
}
