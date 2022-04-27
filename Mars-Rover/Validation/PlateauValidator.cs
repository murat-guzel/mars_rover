using FluentValidation;
using Mars_Rover.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover.Validation
{ 
    public class PlateauValidator : AbstractValidator<Plateau>
    {
        public PlateauValidator(Plateau plateau)
        {
            RuleFor(x => x.Height).GreaterThan(0).WithMessage("Height less than 0");
            RuleFor(x => x.Width).GreaterThan(0).WithMessage("Width less than 0");
           
        }
    }
}
