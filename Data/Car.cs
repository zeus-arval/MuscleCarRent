using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MuscleCarRentProject.Data
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

    public enum Color
    {
        White,
        Black,
        Grey,
        Green,
        Blue,
        Yellow,
        Red
    }

    public class Car
    {
        public int ID { get; set; }
        
        [Required]
        public Brand Brand { get; set; }
        
        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[A-Za-z 0-9]{2,50}", ErrorMessage = "Model's name has to contain letters")]
        public string Model { get; set; }
        
        [Required]
        [StringLength(150)]
        [Display(Name = "Short description")]
        public string ShortDescription { get; set; }
        
        [Required]
        [StringLength(300)]
        [Display(Name = "Long description")]
        public string LongDescription { get; set; }
        
        [Required]
        [RegularExpression(@"^(?:19|20)\d\d$", ErrorMessage = "Incorrect year")]
        [Display(Name = "Production year")]
        public int ProductionYear { get; set; }

        [Display(Name = "Is popular")]
        public bool IsPopular { get; set; }

        [Display(Name = "Is favourite")]
        public bool IsFavourite { get; set; }

        [Required]
        [RegularExpression(@"^[150-999]{3}")]
        public short Power { get; set; }
        
        [Required]
        public Color Color { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Base price")]
        public short BasePrice { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Price per hour")]
        public byte PricePerHour { get; set; }

        [Required]
        [Display(Name = "Number of seats")]
        public byte NumberOfSeats { get; set; }

        [Required]
        [StringLength(50)]
        public string Engine { get; set; }

        [Display(Name = "Needs driver")]
        public bool NeedDriver { get; set; }

        [DataType(DataType.Currency)]
        public short? Surcharge { get; set; }
        
        public ICollection<OrderedDate>? OrderedDates { get; set; }

        [Required]
        [Display(Name = "Driver ID")]
        public int DriverID { get; set; }

        public CarType CarType { get; set; }

        [Display(Name = "Car Type")]
        public int CarTypeID { get; set; }

        [InverseProperty(nameof(Image.Car))]
        public ICollection<Image>? Images { get; set; }

        [Required]
        [Display(Name = "Body type")]
        public BodyType BodyType { get; set; }

        [InverseProperty(nameof(Order.Car))]
        public ICollection<Order>? Orders { get; set; }

        public Driver Driver { get; set; }
    }

}
