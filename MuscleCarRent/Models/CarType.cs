using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace MuscleCarRent.Models
{
    public enum RentType
    {
        Rent,
        WithDriver,
        Fotoset,
        ForEvent
    }
    public class CarType
    {
        public int ID { get; set; }
        public RentType RentType { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}
