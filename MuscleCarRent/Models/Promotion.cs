using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MuscleCarRent.Models
{
    public enum PromotionType
    {
        PersonalPromotion,
        SocialPromotion
    }

    public class Promotion : Order
    {
        public int Discount { get; set; }
        [Display(Name = "Valid until")]
        public DateTime ValidUntil { get; set; }
        [Display(Name = "Is available")]
        public bool IsAvailable { get; set; }
        [Display(Name = "Promotion type")]
        public PromotionType PromotionType { get; set; }
    }
}