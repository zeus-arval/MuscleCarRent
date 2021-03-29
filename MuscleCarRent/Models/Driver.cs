using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuscleCarRent.Models
{
    public class Driver : Person
    {
        public bool IsAvailable { get; set; }
        public ICollection<OrderedDate> OrderedDates{ get; set; }
        public ICollection<Car>? Cars { get; set; }

    }
}
