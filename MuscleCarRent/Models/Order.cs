using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MuscleCarRent.Models
{
    public class Order
    {
        public int ID { get; set; }
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


        public Car Car { get; set; }
        public Account Account { get; set; }

        public int CarID
        {
            get => default;
            set
            {
            }
        }

        public int AccountID
        {
            get => default;
            set
            {
            }
        }
    }
}
