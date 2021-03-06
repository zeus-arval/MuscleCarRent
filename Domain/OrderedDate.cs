using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuscleCarRentProject.Data;
using MuscleCarRentProject.Domain;
using MuscleCarRentProject.Domain.Common;
using MuscleCarRentProject.Domain.Repos;

namespace Domain
{
    public class OrderedDate : BaseEntity<OrderedDateData>
    {
        public OrderedDate() : this(null){}

        public OrderedDate(OrderedDateData o) : base(o)
        {
            car = getLazy<Car, ICarRepo>(c => c?.Get(CarID));
        }

        public DateTime OrderDate => Data?.OrderDate ?? default;
        public string CarID => Data?.CarID ?? default;
        public Car Car => car.Value;
        public Lazy<Car> car { get; }
    }
}
