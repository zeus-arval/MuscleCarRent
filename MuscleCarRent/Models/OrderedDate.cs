using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuscleCarRent.Models
{
    public class OrderedDate
    {
        public int ID { get; set; }
        public DateTime OrderDate { get; set; }
        public int CarID { get; set; }
        public int DriverID { get; set; }
        public Car Car { get; set; }
        public Driver Driver { get; set; }
    }
}
