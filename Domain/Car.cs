using System;
using MuscleCarRentProject.Data;
using MuscleCarRentProject.Domain.Common;

namespace Domain
{
    public sealed class Car : BaseEntity<CarData>
    {
        public Car() : this(null){}

        public Car(CarData d) : base(d)
        {

        } 
    }
}
