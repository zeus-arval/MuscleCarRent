﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuscleCarRent.Models
{
    public class Driver : Person
    {
        public bool IsAvailable { get; set; }
        public DateTime[] FreeDates { get; set; }
    }
}
