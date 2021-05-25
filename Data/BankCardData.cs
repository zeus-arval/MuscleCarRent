using System;
using Data.Common;
using System.ComponentModel.DataAnnotations;

namespace MuscleCarRentProject.Data
{
    public sealed class BankCardData : BaseData
    {
        public long CardNumber { get; set; }
        public DateTime ExpirationTime { get; set; }
        public short CVV { get; set; }
        [StringLength(50)] public string AccountId { get; set; }
        [StringLength(50)] public string CardHolderFullName { get; set; }
    }
}
