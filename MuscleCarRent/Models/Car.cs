using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MuscleCarRent.Models
{
    public enum Brand
    {
        Dodge,
        Ford
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
        public DateTime ProductionDate { get; set; }
        public List<string> ImagesList { get; set; }
        public bool IsPopular { get; set; }
        public bool IsFavourite { get; set; }
        public short Power { get; set; }
        public short BasePerHour { get; set; }
        public short BasePrice { get; set; }
        public byte PricePerHour { get; set; }
        public byte NumberOfSeats { get; set; }

        public BodyType BodyType { get; set; }
        public ICollection<Order>? Orders { get; set; }
        public ICollection<Promotion>? Promotions { get; set; }
        public PersonalPromotion? PersonalPromotion { get; set; }

    }
}
