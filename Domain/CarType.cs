﻿using System;
using System.Collections.Generic;
using MuscleCarRentProject.Data;
using MuscleCarRentProject.Domain.Common;
using MuscleCarRentProject.Domain.Repos;

namespace MuscleCarRentProject.Domain
{
    public sealed class CarType : BaseEntity<CarTypeData>
    {
        public CarType() : this(null){}
        public CarType(CarTypeData c) : base(c)
        {
            cars = getLazy<Car, ICarsRepo>(c => c.GetByCarTypeId(Id));
        }
        public RentTypeEnum RentType => Data?.RentType ?? RentTypeEnum.Rent;
        public string RentTypeName => Data?.RentType.ToString();
        public ICollection<Car> Cars => cars.Value;
        internal Lazy<ICollection<Car>> cars { get; }
    }
}
