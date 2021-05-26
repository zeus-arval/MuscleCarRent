using System;
using Data.Common;
using System.ComponentModel.DataAnnotations;

namespace MuscleCarRentProject.Data
{
    public sealed class OrderedDateData : BaseData
    {
        public DateTime OrderDate { get; set; }
        [StringLength(50)] public string CarModel { get; set; }
        [StringLength(50)] public string CarId { get; set; }
    }
}
