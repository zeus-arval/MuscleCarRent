using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuscleCarRent.Models
{
    public class Image
    {
        public int ID { get; set; }
        public string ImagePath { get; set; }

        public Car Car { get; set; }
        public int CarID { get; set; }
    }
}
