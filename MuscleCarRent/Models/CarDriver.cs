using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuscleCarRent.Models
{
    public class CarDriver : Car
    {
        public byte Surcharge { get; set; }
        public Driver Driver { get; set; }
    }
}
