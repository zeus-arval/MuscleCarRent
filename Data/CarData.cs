using Data.Common;

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
        public string DriverId { get; set; }
        public string CarTypeId { get; set; }
        public BodyTypeEnum BodyType { get; set; }
    }
}
