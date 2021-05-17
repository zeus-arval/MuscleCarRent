using System.ComponentModel.DataAnnotations;
using MuscleCarRentProject.Facade.Common;

namespace Facade
{
    public sealed class DriverView : BaseView
    {
        [Display(Name = "Is available")]
        public bool IsAvailable { get; set; }
    }
}
