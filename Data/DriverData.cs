using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MuscleCarRentProject.Data.Common;

namespace MuscleCarRentProject.Data
{
    public sealed class DriverData : PersonInfoData
    {
        [Display(Name = "Is available")]
        public bool IsAvailable { get; set; }
        public ICollection<CarData>? Cars { get; set; }
    }
}
