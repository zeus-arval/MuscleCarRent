using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MuscleCarRentProject.Data
{
    public class Driver : Person
    {
        [Display(Name = "Is available")]
        public bool IsAvailable { get; set; }
        public ICollection<Car>? Cars { get; set; }

    }
}
