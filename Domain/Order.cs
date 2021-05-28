using System;
using MuscleCarRentProject.Data;
using MuscleCarRentProject.Domain;
using MuscleCarRentProject.Domain.Common;
using MuscleCarRentProject.Domain.Repos;

namespace Domain.Repos
{
    public sealed class Order : BaseEntity<OrderData>
    {
        public Order() : this(null){}
        public Order(OrderData o) : base(o)
        {
            car = getLazy<Car, ICarsRepo>(c => c.Get(CarId));
            account = getLazy<Account, IAccountsRepo>(a => a.Get(AccountId));
            promotion = getLazy<Promotion, IPromotionRepo>(p => p.Get(PromotionId));
        }
        public DateTime OrderDate => Data?.OrderDate ?? default;
        public DateTime RentDate => Data?.RentDate ?? default;
        public decimal TotalPrice => Data?.TotalPrice - Promotion?.Discount ?? default;
        public byte HourAmount => Data?.HourAmmount ?? default;
        public bool HasBankCard => Data?.HasBankCard ?? default;

        public string CarModel => Car?.Model ?? string.Empty;
        public string CarId => Data?.CarId ?? string.Empty;
        public Car Car => car.Value;
        public Lazy<Car> car { get; }

        public string AccountFullName => Account?.FullName ?? string.Empty;
        public string AccountId => Data?.AccountId ?? string.Empty;
        public Account Account => account.Value;
        public Lazy<Account> account { get; }

        public string PromotionName => Data?.PromotionName ?? string.Empty;
        public string PromotionId => Data?.PromotionId ?? string.Empty;
        public Promotion Promotion => promotion.Value ?? null;
        public Lazy<Promotion> promotion { get; }
    }
}
