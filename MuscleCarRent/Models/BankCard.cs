using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuscleCarRent.Models
{
    public class BankCard
    {
        public int ID { get; set; }
        public long CardNumber { get; set; }
        public string CardHolderFullName { get; set; }
        public DateTime ExpirationTime { get; set; }
        public short CVV { get; set; }
        public Account Account { get; set; }
    }
}
