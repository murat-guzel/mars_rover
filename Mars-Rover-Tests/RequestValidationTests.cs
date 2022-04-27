using FluentAssertions;
using FluentValidation;
using Mars_Rover.Domain.Concrete;
using Mars_Rover.Validation;
using System;
using Xunit;

namespace Mars_Rover_Tests
{
    public class RequestValidationTests
    {
        [Fact]
        public void Given_InValid_Plateau_Then_Should_RightPosition()
        {

            // Arrange
            var plateau = new Plateau();

            plateau.Height = -1;
            plateau.Width = 1;

            // Act
            PlateauValidator plateauValidator = new PlateauValidator(plateau);


            // Assert
            plateauValidator.Validate(plateau).IsValid.Should().Be(false);
            plateauValidator.Validate(plateau).Errors[0].ErrorMessage.Should().Be("Height less than 0");

        }
        [Fact]
        public void Given_Valid_Plateau_Then_Should_RightPosition()
        {

            // Arrange
            var plateau = new Plateau();

            plateau.Height = 2;
            plateau.Width = 1;

            // Act
            PlateauValidator plateauValidator = new PlateauValidator(plateau);


            // Assert
            plateauValidator.Validate(plateau).IsValid.Should().Be(true);
 
        }
    }
}
