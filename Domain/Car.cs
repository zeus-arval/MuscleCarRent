using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
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
            driver = getLazy<Driver, IDriversRepo>(x => x?.Get(DriverId));
            carType = getLazy<CarType, ICarTypesRepo>(x => x?.Get(CarTypeId));
            images = getLazy<Image, IImagesRepo>(i => i.GetByCarId(Id));
            orderedDates = getLazy<OrderedDate, IOrderedDatesRepo>(o => o?.GetByCarId(Id));
            orders = getLazy<Order, IOrdersRepo>(o => o?.GetByCarId(Id));
        }

        public BrandEnum Brand => Data?.Brand ?? BrandEnum.Other;
        public string Model => Data?.Model ?? string.Empty;
        public string ShortDescription => Data?.ShortDescription ?? string.Empty;
        public string LongDescription => Data?.LongDescription ?? string.Empty;
        public int ProductionYear => Data?.ProductionYear ?? default;
        public bool IsPopular => Data?.IsPopular ?? default;
        public bool IsFavoutire => Data?.IsFavourite ?? default;
        public short Power => Data?.Power ?? default;
        public ColorEnum Color => Data?.Color ?? ColorEnum.Other;
        public short BasePrice => Data?.BasePrice ?? default;
        public byte PricePerHour => Data?.PricePerHour ?? default;
        public byte NumberOfSeats => Data?.NumberOfSeats ?? default;
        public string Engine => Data?.Engine ?? string.Empty;
        public bool NeedDriver => Data?.NeedDriver ?? default;
        public short? Surcharge => Data?.Surcharge ?? null;
        public string DriverId => Data?.DriverId ?? string.Empty;
        public Driver Driver => driver.Value;
        internal Lazy<Driver> driver { get; }
        public string CarTypeId => Data?.CarTypeId ?? string.Empty;
        public CarType CarType => carType.Value;
        internal Lazy<CarType> carType { get; }
        public ICollection<Image> Images => images.Value;
        internal Lazy<ICollection<Image>> images { get; }
        public BodyTypeEnum BodyType => Data?.BodyType ?? BodyTypeEnum.Other;
        public ICollection<OrderedDate> OrderedDates => orderedDates.Value;
        public Lazy<ICollection<OrderedDate>> orderedDates { get; }
        public ICollection<Order> Orders => orders.Value;
        public Lazy<ICollection<Order>> orders { get; }
    }
}
