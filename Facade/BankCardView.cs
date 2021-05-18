﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuscleCarRentProject.Data;
using MuscleCarRentProject.Facade.Common;

namespace Facade
{
    public sealed class BankCardView : BaseView
    {
        public string AccountID { get; set; }
        [Display(Name = "Card number")] public long CardNumber { get; set; }
        [Display(Name = "Card holder full name")] public string CardHolderFullName { get; set; }
        [Display(Name = "Expiration time")] public DateTime ExpirationTime { get; set; }
        public short CVV { get; set; }
    }
}
