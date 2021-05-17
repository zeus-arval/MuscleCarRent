using System;
using System.ComponentModel.DataAnnotations;
using MuscleCarRentProject.Data;
using MuscleCarRentProject.Facade.Common;

namespace Facade
{
    public sealed class PromotionView : BaseView
    {
        [Required] public int Discount { get; set; }
        [Display(Name = "Valid until")] public DateTime ValidUntil { get; set; }
        [Display(Name = "Is available")] public bool IsAvailable { get; set; }
        [Display(Name = "Promotion type")] public PromotionTypeEnum PromotionTypeEnum { get; set; }
    }
}
