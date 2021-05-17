using System.Collections.Generic;
using Core;
using Data.Common;

namespace MuscleCarRentProject.Data
{

    public sealed class CarTypeData : BaseData
    {
        public RentTypeEnum RentTypeEnum { get; set; }
        public ICollection<CarData> Cars { get; set; }
    }
}
