using System;
using System.ComponentModel.DataAnnotations;
using MuscleCarRentProject.Facade.Common;

namespace Facade
{
    public sealed class OrderView : BaseView
    {
        [Required] [Display(Name = "Order date")] public DateTime OrderDate { get; set; }
        [Required] [Display(Name = "Rent date")] public DateTime RentDate { get; set; }
        [Required] [Display(Name = "Total price")] public short TotalPrice { get; set; }
        [Required] [Display(Name = "Hours")] public byte HourAmmount { get; set; }
        [Display(Name = "Has bank card")] public bool HasBankCard { get; set; } = false;

        [Required] public string CarId { get; set; }
        [Display(Name = "Car")] public string CarModel { get; set; }

        [Required] public string AccountId { get; set; }
        [Display(Name = "Account Name")] public string AccountName { get; set; }

        [Required] [Display(Name = "Promotion")] public string PromotionId { get; set; }
        [Required] [Display(Name = "Promotion")] public string PromotionName { get; set; }
    }
}
