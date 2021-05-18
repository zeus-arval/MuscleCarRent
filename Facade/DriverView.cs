using System.ComponentModel.DataAnnotations;
using Facade.Common;
using MuscleCarRentProject.Facade.Common;

namespace Facade
{
    public sealed class DriverView : PersonView
    {
        [Display(Name = "Is available")]
        public bool IsAvailable { get; set; }
    }
}
