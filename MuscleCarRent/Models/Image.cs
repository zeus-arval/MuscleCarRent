using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MuscleCarRent.Models
{
    public class Image
    {
        public int ID { get; set; }
        [Display(Name = "Image path")]
        public string ImagePath { get; set; }

        public Car Car { get; set; }
        public int CarID { get; set; }
    }
}
