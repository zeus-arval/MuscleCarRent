using System;
using Data.Common;

namespace MuscleCarRentProject.Data
{
    public sealed class OrderedDateData : BaseData
    {
        public DateTime OrderDate { get; set; }
        public string CarModel { get; set; }
        public string CarId { get; set; }
    }
}
