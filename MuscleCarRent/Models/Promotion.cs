using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuscleCarRent.Models
{
    public class Promotion : Order
    {
        public int Discount { get; set; }
        public DateTime ValidUntil { get; set; }
        public bool IsAvailable { get; set; }
    }
}