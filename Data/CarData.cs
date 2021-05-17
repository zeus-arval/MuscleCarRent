using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Common;
using MuscleCarRentProject.Core;

namespace MuscleCarRentProject.Data
{
    public sealed class CarData : BaseData
    {
        public BrandEnum Brand { get; set; }
        public string Model { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public int ProductionYear { get; set; }
        public bool IsPopular { get; set; }
        public bool IsFavourite { get; set; }
        public short Power { get; set; }
        public ColorEnum Color { get; set; }
        public short BasePrice { get; set; }
        public byte PricePerHour { get; set; }
        public byte NumberOfSeats { get; set; }
        public string Engine { get; set; }
        public bool NeedDriver { get; set; }
        public short? Surcharge { get; set; }
        public ICollection<OrderedDateData>? OrderedDates { get; set; }
        public string DriverID { get; set; }
        public CarTypeData CarType { get; set; }
        public string CarTypeID { get; set; }
        public ICollection<ImageData>? Images { get; set; }
        public BodyTypeEnum BodyTypeEnum { get; set; }
        public ICollection<OrderData>? Orders { get; set; }
        public DriverData Driver { get; set; }
    }

}
