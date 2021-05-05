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
    public sealed class CarTypeData
    {
        public int ID { get; set; }
        public RentType RentType { get; set; }
        public ICollection<CarData> Cars { get; set; }
    }
}
