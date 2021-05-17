using System;
using System.ComponentModel.DataAnnotations;
using Data.Common;

namespace MuscleCarRentProject.Data
{
    public class OrderData : BaseData
    {
        [Display(Name = "Order date")]
        public DateTime OrderDate { get; set; }
        [Display(Name = "Rent date")]
        public DateTime RentDate { get; set; }
        [Display(Name = "Total price")]
        public short TotalPrice { get; set; }
        [Display(Name = "Hour ammount")]
        public byte HourAmmount { get; set; }
        [Display(Name = "Has bank card")]
        public bool HasBankCard { get; set; }

        public CarData Car { get; set; }
        public AccountData Account { get; set; }

        public string CarID
        {
            get => default;
            set
            {
            }
        }

        public string AccountID
        {
            get => default;
            set
            {
            }
        }
    }
}
