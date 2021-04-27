﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MuscleCarRent.Models
{
    public class BankCard
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
        public Account Account { get; set; }
    }
}
