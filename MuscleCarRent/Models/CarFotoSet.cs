using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuscleCarRent.Models
{
    public class CarFotoSet : Car
    {
        public int PhotoAmount { get; set; }
        public DateTime[] OrderedDates { get; set; }
    }
}
