using FluentValidation;
using Mars_Rover.Domain.Concrete;
using Mars_Rover.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover.Validation
{
    public class CoordinateValidator : AbstractValidator<Coordinate>
    {
        public CoordinateValidator(Coordinate coordinate)
        {
            RuleFor(x => x.X).NotEmpty().GreaterThan(0).WithMessage("coordinate X is empty or less than 0");
            RuleFor(x => x.Y).NotEmpty().GreaterThan(0).WithMessage("coordinate Y is empty or less than 0");

        }
    }
}
