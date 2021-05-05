using System.Collections.Generic;

namespace MuscleCarRentProject.Data
{
    public enum RentType
    {
        Rent,
        WithDriver,
        Fotoset,
        ForEvent
    }
    public sealed class CarType
    {
        public int ID { get; set; }
        public RentType RentType { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}
