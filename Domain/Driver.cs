﻿using System;
using System.Collections.Generic;
using MuscleCarRentProject.Data;
using MuscleCarRentProject.Domain;
using MuscleCarRentProject.Domain.Common;
using MuscleCarRentProject.Domain.Repos;

namespace Domain
{
    public sealed class Driver : Person<DriverData>
    {
        public Driver() : this(null){}

        public Driver(DriverData d) : base(d)
        {
            cars = getLazy<Car, ICarsRepo>(x => x?.GetByDriverId(Id));
        }
        public bool IsAvailable => Data?.IsAvailable ?? false;
        public ICollection<Car> Cars => cars.Value;
        public Lazy<ICollection<Car>> cars { get; }
    }
}
