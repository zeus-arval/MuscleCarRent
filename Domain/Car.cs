using System;
using System.Collections.Generic;
using Domain;
using Domain.Repos;
using MuscleCarRentProject.Data;
using MuscleCarRentProject.Domain.Common;

namespace MuscleCarRentProject.Domain
{
    public sealed class Car : BaseEntity<CarData>
    {
        public Car() : this(null){}

        public Car(CarData d) : base(d)
        {
            driver = getLazy<Driver, IDriverRepo>(x => x?.Get(DriverID));
            carType = getLazy<CarType, ICarTypeRepo>(x => x?.Get(CarTypeID));
            images = getLazy<Image, IImageRepo>(i => i.GetByCarID(ID));
            orderedDates = getLazy<OrderedDate, IOrderedDateRepo>(o => o?.GetByCarID(ID));
        }

        public BrandEnum Brand => Data?.Brand ?? BrandEnum.Other;
        public string Model => Data?.Model ?? unspec;
        public string ShortDescription => Data?.ShortDescription ?? unspec;
        public string LongDescription => Data?.LongDescription ?? unspec;
        public int ProductionYear => Data?.ProductionYear ?? default;
        public bool IsPopular => Data?.IsPopular ?? default;
        public bool IsFavoutire => Data?.IsFavourite ?? default;
        public short Power => Data?.Power ?? default;
        public ColorEnum Color => Data?.Color ?? ColorEnum.Other;
        public short BasePrice => Data?.BasePrice ?? default;
        public byte PricePerHour => Data?.PricePerHour ?? default;
        public byte NumberOfSeats => Data?.NumberOfSeats ?? default;
        public string Engine => Data?.Engine ?? unspec;
        public bool NeedDriver => Data?.NeedDriver ?? default;
        public short? Surcharge => Data?.Surcharge ?? null;
        public string DriverID => Data?.DriverID ?? unspec;
        public Driver Driver => driver.Value;
        internal Lazy<Driver> driver { get; }
        public string CarTypeID => Data?.CarTypeID ?? unspec;
        public CarType CarType => carType.Value;
        internal Lazy<CarType> carType { get; }
        public ICollection<Image> Images => images.Value;
        internal Lazy<ICollection<Image>> images { get; }
        public BodyTypeEnum BodyType => Data?.BodyTypeEnum ?? BodyTypeEnum.Other;
        public ICollection<OrderedDate> OrderedDates => orderedDates.Value;
        public Lazy<ICollection<OrderedDate>> orderedDates { get; }
    }
}
