using System;
using Domain.Repos;
using MuscleCarRentProject.Data;
using MuscleCarRentProject.Domain;
using MuscleCarRentProject.Domain.Common;
using MuscleCarRentProject.Domain.Repos;

namespace Domain
{
    public class Promotion : BaseEntity<PromotionData>
    {
        public Promotion() : this(null) { }
        public Promotion(PromotionData p) : base(p)
        {
            car = getLazy<Car, ICarsRepo>(c => c.Get(CarId));
            account = getLazy<Account, IAccountsRepo>(a => a.Get(AccountId));
        }
        public DateTime ValidUntil => Data?.ValidUntil ?? default;
        public bool IsAvailable => Data?.IsAvailable ?? default;
        public decimal Discount => Data?.Discount ?? default;
        public PromotionTypeEnum PromotionTypeEnum => Data?.PromotionTypeEnum ?? PromotionTypeEnum.SocialPromotion;

        public string CarModel => Car?.Model ?? string.Empty;
        public string CarId => Data?.CarId ?? string.Empty;
        public Car Car => car.Value;
        public Lazy<Car> car { get; }

        public string AccountFullName => Account?.FullName ?? String.Empty;
        public string AccountId => Data?.AccountId ?? string.Empty;
        public Account Account => account.Value;
        public Lazy<Account> account { get; }
    }
}
