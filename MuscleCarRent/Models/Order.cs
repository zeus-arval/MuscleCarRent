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
        public bool HasBankCard { get; set; }

        public ICollection<Car> Cars { get; set; }
        public Account Account { get; set; }
    }
}
