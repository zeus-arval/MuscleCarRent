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
        public Promotion() : this(null){}
        public Promotion(PromotionData p) : base(p)
        {
            car = getLazy<Car, ICarsRepo>(c => c.Get(CarId));
            account = getLazy<Account, IAccountsRepo>(a => a.Get(AccountId));
        }
        public DateTime ValidUntil => Data?.ValidUntil ?? default;
        public DateTime OrderDate => Data?.OrderDate ?? default;
        public DateTime RentDate => Data?.RentDate ?? default;
        public short TotalPrice => Data?.TotalPrice ?? default;
        public byte HourAmount => Data?.HourAmmount ?? default;
        public bool HasBankCard => Data?.HasBankCard ?? default;
        public string CarId => Data?.CarId ?? string.Empty;
        public int Discount => Data?.Discount ?? default;
        public bool IsAvailable => Data?.IsAvailable ?? default;
        public PromotionTypeEnum PromotionTypeEnum => Data?.PromotionTypeEnum ?? PromotionTypeEnum.SocialPromotion;
        public Car Car => car.Value;
        public Lazy<Car> car { get; }
        public string AccountId => Data?.AccountId ?? string.Empty;
        public Account Account => account.Value;
        public Lazy<Account> account { get; }
    }
}
