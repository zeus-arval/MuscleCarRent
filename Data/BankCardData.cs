using System;
using Data.Common;

namespace MuscleCarRentProject.Data
{
    public sealed class BankCardData : BaseData
    {
        public string AccountID { get; set; }
        public long CardNumber { get; set; }
        public string CardHolderFullName { get; set; }
        public DateTime ExpirationTime { get; set; }
        public short CVV { get; set; }
    }
}
