using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MuscleCarRentProject.Data
{
    public sealed class DriverData : PersonData
    {
        [Display(Name = "Is available")]
        public bool IsAvailable { get; set; }
        public ICollection<CarData>? Cars { get; set; }

    }
}
