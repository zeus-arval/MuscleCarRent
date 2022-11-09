using Data.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MuscleCarRentProject.Data
{

    public sealed class PromotionData : BaseData
    {
        [Column(TypeName = "decimal(18,4)")] public decimal Discount { get; set; }
        public DateTime ValidUntil { get; set; }
        public bool IsAvailable { get; set; }
        public PromotionTypeEnum PromotionTypeEnum { get; set; }

        [StringLength(50)] public string AccountFullName { get; set; }
        [StringLength(50)] public string AccountId { get; set; }
        
        [StringLength(50)] public string CarModel { get; set; }
        [StringLength(50)] public string CarId { get; set; }
    }
}