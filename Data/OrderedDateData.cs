using System;
using System.ComponentModel.DataAnnotations;
using Data.Common;

namespace MuscleCarRentProject.Data
{
    public sealed class OrderedDateData : BaseData
    {
        [Display(Name = "Order date")]
        public DateTime OrderDate { get; set; }
        public int CarID { get; set; }
        //public int DriverID { get; set; }
        public CarData Car { get; set; }
      //// public Driver Driver { get; set; }
    }
}
