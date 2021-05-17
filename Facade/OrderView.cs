using System;
using System.ComponentModel.DataAnnotations;
using MuscleCarRentProject.Facade.Common;

namespace Facade
{
    public sealed class OrderView : BaseView
    {
        [Required]
        [Display(Name = "Order date")]
        public DateTime OrderDate { get; set; }
        [Required] [Display(Name = "Rent date")] 
        public DateTime RentDate { get; set; }
        [Required] [Display(Name = "Total price")] 
        public short TotalPrice { get; set; }
        [Required]
        [Display(Name = "Hour ammount")] 
        public byte HourAmmount { get; set; }
        [Display(Name = "Has bank card")] 
        public bool HasBankCard { get; set; } = false;
        [Required]
        public string CarID { get; set; }
        [Required]
        public string AccountID { get; set; }
    }
}
