using System;
using System.ComponentModel.DataAnnotations;
using Data.Common;

namespace MuscleCarRentProject.Data
{
    public sealed class OrderedDateData : BaseData
    {
        [Display(Name = "Order date")]
        public DateTime OrderDate { get; set; }
        public string CarID { get; set; }
        public CarData Car { get; set; }
    }
}
