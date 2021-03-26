using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuscleCarRent.Models
{
    public struct Event
    {
        public enum EventType
        {
            Birthday,
            Wedding,
            BabyBirth,
            Corporate,
            Other
        }

    }
    public class CarEvent : Car
    {
        public Event Event { get; set; }
        public bool NeedDriver { get; set; }
        public byte SurchargeForEvent { get; set; }
        public Driver Driver { get; set; }
    }
}
