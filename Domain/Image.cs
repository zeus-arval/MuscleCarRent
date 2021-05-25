using System;
using MuscleCarRentProject.Data;
using MuscleCarRentProject.Domain;
using MuscleCarRentProject.Domain.Common;
using MuscleCarRentProject.Domain.Repos;
using System.Runtime.InteropServices.ComTypes;

namespace Domain
{
    public sealed class Image : BaseEntity<ImageData>
    {
        public Image() : this(null){}

        public Image(ImageData i) : base(i)
        {
            car = getLazy<Car, ICarsRepo>(c => c.Get(CarId));
        }

        public string CarModel => Car?.Model ?? string.Empty;
        public string CarId => Data?.CarId ?? string.Empty;
        public Car Car => car.Value;
        internal Lazy<Car> car { get; }

    }
}
