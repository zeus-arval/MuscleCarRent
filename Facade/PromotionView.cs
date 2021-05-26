using System;
using System.ComponentModel.DataAnnotations;
using MuscleCarRentProject.Data;
using MuscleCarRentProject.Facade.Common;

namespace Facade
{
    public sealed class PromotionView : BaseView
    {
        [Display(Name = "Discount")]
        [Required] public int Discount { get; set; }
        [Display(Name = "Valid until")] public DateTime ValidUntil { get; set; }
        [Display(Name = "Is available")] public bool IsAvailable { get; set; }
        [Display(Name = "Promotion type")] public PromotionTypeEnum PromotionTypeEnum { get; set; }
        [Required] [Display(Name = "Car")] public string CarId { get; set; }
        [Display(Name = "Car")] public string CarModel { get; set; }
        [Required] [Display(Name = "Account")] public string AccountId { get; set; }
        [Display(Name = "Account")] public string AccountFullName { get; set; }
    }
}
