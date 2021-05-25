using System.ComponentModel.DataAnnotations;
using MuscleCarRentProject.Data;
using MuscleCarRentProject.Facade.Common;

namespace MuscleCarRentProject.Facade
{
    public sealed class CarView : BaseView
    {
        [Required] 
        public BrandEnum Brand { get; set; }
        [Required] [StringLength(50)] [RegularExpression(@"^[A-Za-z 0-9]{2,50}", ErrorMessage = "Model's name has to contain letters")]
        public string Model { get; set; }
        [Required] [StringLength(150)] [Display(Name = "Short description")]
        public string ShortDescription { get; set; }
        [Required] [StringLength(300)] [Display(Name = "Long description")]
        public string LongDescription { get; set; }
        [Required] [RegularExpression(@"^(?:19|20)\d\d$", ErrorMessage = "Incorrect year")] [Display(Name = "Production year")]
        public int ProductionYear { get; set; }
        [Display(Name = "Is popular")]
        public bool IsPopular { get; set; }
        [Display(Name = "Is favourite")]
        public bool IsFavourite { get; set; }
        [Required] [RegularExpression(@"^[150-999]{3}")]
        public short Power { get; set; }
        [Required]
        public ColorEnum Color { get; set; }
        [Required] [DataType(DataType.Currency)] [Display(Name = "Base price")]
        public decimal BasePrice { get; set; }
        [Required] [DataType(DataType.Currency)] [Display(Name = "Price per hour")]
        public decimal PricePerHour { get; set; }
        [Required] [Display(Name = "Number of seats")]
        public byte NumberOfSeats { get; set; }
        [Required] [StringLength(50)]
        public string Engine { get; set; }
        [Display(Name = "Needs driver")] 
        public bool NeedDriver { get; set; }
        [DataType(DataType.Currency)]
        public decimal? Surcharge { get; set; }
        [Required]
        [Display(Name = "Driver")]
        public int DriverId { get; set; }
        [Display(Name = "Driver")]
        public string DriverFullName { get; set; }
        [Display(Name = "Car Type")]
        public int CarTypeId { get; set; }
        [Display(Name = "Car type")]
        public string CarTypeName { get; set; }
        [Required] [Display(Name = "Body type")]
        public BodyTypeEnum BodyType { get; set; }
    }
}
