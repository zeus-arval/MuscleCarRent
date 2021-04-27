using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MuscleCarRent.Models
{
    public class Driver : Person
    {
        [Display(Name = "Is available")]
        public bool IsAvailable { get; set; }
        public ICollection<Car>? Cars { get; set; }

    }
}
