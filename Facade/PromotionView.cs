using System;
using System.ComponentModel.DataAnnotations;
using MuscleCarRentProject.Data;
using MuscleCarRentProject.Facade.Common;

namespace Facade
{
    public sealed class PromotionView : BaseView
    {
        [Required]
        [Display(Name = "Order date")]
        public DateTime OrderDate { get; set; }
        [Required]
        [Display(Name = "Rent date")]
        public DateTime RentDate { get; set; }
        [Required]
        [Display(Name = "Total price")]
        public short TotalPrice { get; set; }
        [Required]
        [Display(Name = "Hour ammount")]
        public byte HourAmmount { get; set; }
        [Display(Name = "Has bank card")]
        public bool HasBankCard { get; set; } = false;
        [Required]
        public string CarId { get; set; }
        [Display(Name = "Car")]
        public string CarModel { get; set; }
        [Required]
        public string AccountId { get; set; }
        [Display(Name = "Account Name")]
        public string AccountName { get; set; }
        [Required] public int Discount { get; set; }
        [Display(Name = "Valid until")] public DateTime ValidUntil { get; set; }
        [Display(Name = "Is available")] public bool IsAvailable { get; set; }
        [Display(Name = "Promotion type")] public PromotionTypeEnum PromotionTypeEnum { get; set; }
    }
}
