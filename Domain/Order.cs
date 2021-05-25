using System;
using MuscleCarRentProject.Data;
using MuscleCarRentProject.Domain;
using MuscleCarRentProject.Domain.Common;
using MuscleCarRentProject.Domain.Repos;

namespace Domain.Repos
{
    public class Order : BaseEntity<OrderData>
    {
        public Order() : this(null){}
        public Order(OrderData o) : base(o)
        {
            car = getLazy<Car, ICarsRepo>(c => c.Get(CarId));
            account = getLazy<Account, IAccountsRepo>(a => a.Get(AccountId));
        }
        public DateTime OrderDate => Data?.OrderDate ?? default;
        public DateTime RentDate => Data?.RentDate ?? default;
        public short TotalPrice => Data?.TotalPrice ?? default;
        public byte HourAmount => Data?.HourAmmount ?? default;
        public bool HasBankCard => Data?.HasBankCard ?? default;
        public string CarId => Data?.CarId ?? string.Empty;
        public Car Car => car.Value;
        public Lazy<Car> car { get; }
        public string AccountId => Data?.AccountId ?? string.Empty;
        public Account Account => account.Value;
        public Lazy<Account> account { get; }
    }
}
