using System;
using System.ComponentModel.DataAnnotations;

namespace MuscleCarRentProject.Data
{
    public sealed class BankCardData
    {
        public int ID { get; set; }
        public int AccountID { get; set; }
        [Display(Name = "Card number")]
        public long CardNumber { get; set; }
        [Display(Name = "Card holder full name")]
        public string CardHolderFullName { get; set; }
        [Display(Name = "Expiration time")]
        public DateTime ExpirationTime { get; set; }
        public short CVV { get; set; }
        public AccountData Account { get; set; }
    }
}
