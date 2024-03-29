﻿using Data.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MuscleCarRentProject.Data
{
    public sealed class CarData : BaseData
    {
        [StringLength(50)] public string Model { get; set; }
        [StringLength(50)] public string ShortDescription { get; set; }
        [StringLength(50)] public string LongDescription { get; set; }
        [StringLength(50)] public string Engine { get; set; }
        public int ProductionYear { get; set; }
        public bool IsPopular { get; set; }
        public bool IsFavourite { get; set; }
        public bool NeedDriver { get; set; }
        public short Power { get; set; }
        [Column(TypeName = "decimal(18,4)")] public decimal BasePrice { get; set; }
        [Column(TypeName = "decimal(18,4)")] public decimal? Surcharge { get; set; }
        [Column(TypeName = "decimal(18,4)")] public decimal PricePerHour { get; set; }
        public byte NumberOfSeats { get; set; }
        [StringLength(50)] public string CarTypeId { get; set; }
        [StringLength(50)] public string DriverId { get; set; }
        public BrandEnum Brand { get; set; }
        public ColorEnum Color { get; set; }
        public BodyTypeEnum BodyType { get; set; }
    }
}
