using Mars_Rover.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover.Domain.Abstract
{
    public interface IRover
    {
        void Move(Motion motion);

    }
}
