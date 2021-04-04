using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MuscleCarRent.Models
{
    public enum Brand
    {
        Dodge,
        Ford,
        Plymouth
    }

    public enum BodyType
    {
        FullSize,
        PonyCar,
        Luxury,
        Sport,
        CoupeUtility
    }

    public class Car
    {
        public int ID { get; set; }
        public Brand Brand { get; set; }
        public string Model { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public int ProductionYear { get; set; }
        public bool IsPopular { get; set; }
        public bool IsFavourite { get; set; }
        public short Power { get; set; }
        public string Color { get; set; }
        public short BasePrice { get; set; }
        public byte PricePerHour { get; set; }
        public byte NumberOfSeats { get; set; }
        public string Engine { get; set; }
        public bool NeedDriver { get; set; }
        public short? Surcharge { get; set; }
        public ICollection<OrderedDate>? OrderedDates { get; set; }
        public int DriverID { get; set; }

        public CarType CarType { get; set; }
        public int CarTypeID { get; set; }

        [InverseProperty(nameof(Image.Car))]
        public ICollection<Image>? Images { get; set; }

        public BodyType BodyType { get; set; }

        [InverseProperty(nameof(Order.Car))]
        public ICollection<Order>? Orders { get; set; }

        public Driver Driver { get; set; }
    }

}
