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
        public Account() : this(null){}

        public Account(AccountData a) : base(a)
        {
            bankCard = getLazy<BankCard, IBankCardsRepo>(b => b.Get(BankCardId));
            orders = getLazy<Order, IOrdersRepo>(o => o?.GetByAccountId(Id));
            accessType = getLazy<AccessType, IAccessTypesRepo>(a => a?.Get(AccessTypeId));
        }
        public string Username => Data?.Username ?? string.Empty;
        public string Password => Data?.Username ?? string.Empty;
        public string Email => Data?.Email ?? string.Empty;
        public string PhoneNumber => Data?.PhoneNumber ?? string.Empty;
        public string PersonalPhoto => Data?.PersonalPhoto ?? string.Empty;
        public string DrivingLicense => Data?.DrivingLicense ?? string.Empty;
        public DateTime RegistrationDate => Data?.RegistrationDate ?? default;
        public bool IsDrivingLicenseValid => Data?.IsDrivingLicenseValid ?? default;
        public string BankCardId => Data?.BankCardId ?? string.Empty;
        public ICollection<Order> Order => orders.Value;
        public Lazy<ICollection<Order>> orders { get; }
        public BankCard BankcCard => bankCard.Value;
        public Lazy<BankCard> bankCard { get; }
        public string AccessTypeId => Data?.AccessTypeId ?? string.Empty;
        public AccessType AccessType => accessType.Value;
        public Lazy<AccessType> accessType { get; }
    }
}
