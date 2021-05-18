using System;
using System.Collections.Generic;
using MuscleCarRentProject.Data;
using MuscleCarRentProject.Domain.Common;
using MuscleCarRentProject.Domain.Repos;

namespace MuscleCarRentProject.Domain
{
    public class CarType : BaseEntity<CarTypeData>
    {
        public CarType() : this(null){}
        public CarType(CarTypeData c) : base(c)
        {
            cars = getLazy<Car, ICarsRepo>(c => c.GetByCarTypeID(ID));
        }
        public RentTypeEnum RentType => Data?.RentTypeEnum ?? RentTypeEnum.Rent;
        public ICollection<Car> Cars => cars.Value;
        internal Lazy<ICollection<Car>> cars { get; }
    }
}
