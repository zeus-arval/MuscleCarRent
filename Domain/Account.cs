using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuscleCarRentProject.Data;
using MuscleCarRentProject.Domain.Common;

namespace Domain.Repos
{
    public class Account : Person<AccountData>
    {
        public Account() : this(null) { }

        public Account(AccountData a) : base(a)
        {
            bankCard = getLazy<BankCard, IBankCardsRepo>(b => b.Get(BankCardId));
            accessType = getLazy<AccessType, IAccessTypesRepo>(a => a?.Get(AccessTypeId));
            orders = getLazy<Order, IOrdersRepo>(o => o?.GetByAccountId(Id));
            promotions = getLazy<Promotion, IPromotionRepo>(p => p.GetByAccountId(Id));
        }
        public string Username => Data?.Username ?? string.Empty;
        public string Password => Data?.Username ?? string.Empty;
        public string Email => Data?.Email ?? string.Empty;
        public string PhoneNumber => Data?.PhoneNumber ?? string.Empty;
        public string PersonalPhoto => Data?.PersonalPhoto ?? string.Empty;
        public string DrivingLicense => Data?.DrivingLicense ?? string.Empty;
        public DateTime RegistrationDate => Data?.RegistrationDate ?? default;
        public bool IsDrivingLicenseValid => Data?.IsDrivingLicenseValid ?? default;

        public ICollection<Order> Orders => orders.Value;
        public Lazy<ICollection<Order>> orders { get; }

        public ICollection<Promotion> Promotions => promotions.Value;
        public Lazy<ICollection<Promotion>> promotions { get; }

        public string BankCardNumber => BankCard?.CardNumber.ToString() ?? string.Empty;
        public string BankCardId => Data?.BankCardId ?? string.Empty;
        public BankCard BankCard => bankCard.Value;
        public Lazy<BankCard> bankCard { get; }

        public string AccessTypeName => AccessType?.AccessLevel.ToString() ?? AccessLevelEnum.User.ToString();
        public string AccessTypeId => Data?.AccessTypeId ?? string.Empty;
        public AccessType AccessType => accessType.Value;
        public Lazy<AccessType> accessType { get; }
    }
}
