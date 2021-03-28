using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuscleCarRent.Models
{
    public class Order
    {
        public int ID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RentDate { get; set; }
        public short TotalPrice { get; set; }
        public byte HourAmmount { get; set; }
        public bool HasBankCard { get; set; }


        public Car Car { get; set; }
        public Account Account { get; set; }
    }
}
