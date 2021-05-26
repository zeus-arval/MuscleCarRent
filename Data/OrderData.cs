using System;
using Data.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MuscleCarRentProject.Data
{
    public class OrderData : BaseData
    {
        public DateTime OrderDate { get; set; }
        public DateTime RentDate { get; set; }
        [Column(TypeName = "decimal(18,4)")] public decimal TotalPrice { get; set; }
        public byte HourAmmount { get; set; }
        public bool HasBankCard { get; set; }

        [StringLength(50)] public string CarModel { get; set; }
        [StringLength(50)] public string CarId { get; set; }
        
        [StringLength(50)] public string AccountFullName { get; set; }
        [StringLength(50)] public string AccountId { get; set; }

        [StringLength(50)] public string PromotionName { get; set; }
        [StringLength(50)] public string PromotionId { get; set; }

    }
}
