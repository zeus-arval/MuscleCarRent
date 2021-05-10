using System.Collections.Generic;
using Core;

namespace MuscleCarRentProject.Data
{

    public sealed class CarTypeData : UniqueItem
    {
        public RentType RentType { get; set; }
        public ICollection<CarData> Cars { get; set; }
    }
}
