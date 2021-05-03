using System;
using System.ComponentModel.DataAnnotations;

namespace MuscleCarRentProject.Data
{
    public class OrderedDate
    {
        public int ID { get; set; }
        [Display(Name = "Order date")]
        public DateTime OrderDate { get; set; }
        public int CarID { get; set; }
        //public int DriverID { get; set; }
        public Car Car { get; set; }
      //// public Driver Driver { get; set; }
    }
}
