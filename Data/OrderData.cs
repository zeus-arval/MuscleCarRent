using System;
using Data.Common;

namespace MuscleCarRentProject.Data
{
    public class OrderData : BaseData
    {
        public DateTime OrderDate { get; set; }
        public DateTime RentDate { get; set; }
        public short TotalPrice { get; set; }
        public byte HourAmmount { get; set; }
        public bool HasBankCard { get; set; }
        public string CarId { get; set; }
        public string AccountId { get; set; }
    }
}
