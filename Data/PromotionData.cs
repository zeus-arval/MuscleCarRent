using System;

namespace MuscleCarRentProject.Data
{

    public sealed class PromotionData : OrderData
    {
        public int Discount { get; set; }
        public DateTime ValidUntil { get; set; }
        public bool IsAvailable { get; set; }
        public PromotionTypeEnum PromotionTypeEnum { get; set; }
    }
}