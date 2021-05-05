using System.Collections.Generic;
using Core;

namespace MuscleCarRentProject.Data
{
    public enum RentType
    {
        Rent,
        WithDriver,
        Fotoset,
        ForEvent
    }
    public sealed class CarTypeData : UniqueItem
    {
        public RentType RentType { get; set; }
        public ICollection<CarData> Cars { get; set; }
    }
}
