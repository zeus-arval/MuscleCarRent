using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuscleCarRentProject.Data;
using MuscleCarRentProject.Facade.Common;

namespace Facade
{
    public sealed class OrderedDateView : BaseView
    {
        [Display(Name = "Order date")] [Required] 
        public DateTime OrderDate { get; set; }
        [Required] public string CarID { get; set; }
        [Display(Name = "Car Model")]
        public string CarModel { get; set; }
    }
}
