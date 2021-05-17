using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MuscleCarRentProject.Data;
using MuscleCarRentProject.Facade.Common;
using Color = System.Drawing.Color;

namespace MuscleCarRentProject.Facade
{
    public sealed class CarView : BaseView
    {
        [Required]
        public BrandEnum Brand { get; set; }

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
        public ColorEnum Color { get; set; }

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

        public ICollection<OrderedDateData>? OrderedDates { get; set; }

        [Required]
        [Display(Name = "Driver ID")]
        public int DriverID { get; set; }

        public CarTypeData CarType { get; set; }

        [Display(Name = "Car Type")]
        public int CarTypeID { get; set; }

        [InverseProperty(nameof(ImageData.Car))]
        public IList<ImageData>? Images { get; set; }

        [Required]
        [Display(Name = "Body type")]
        public BodyType BodyType { get; set; }

        [InverseProperty(nameof(OrderData.Car))]
        public ICollection<OrderData>? Orders { get; set; }

        public DriverData Driver { get; set; }
    }
}
