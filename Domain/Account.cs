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
            bankCard = getLazy<BankCard, IBankCardsRepo>(b => b.GetById(ID));
            orders = getLazy<Order, IOrdersRepo>(o => o?.GetByAccountID(ID));
            accessType = getLazy<AccessType, IAccessTypesRepo>(a => a?.GetById(ID));
        }
        public string Username => Data?.Username ?? unspec;
        public string Password => Data?.Username ?? unspec;
        public string Email => Data?.Email ?? unspec;
        public string PhoneNumber => Data?.PhoneNumber ?? unspec;
        public string PersonalPhoto => Data?.PersonalPhoto ?? unspec;
        public string DrivingLicense => Data?.DrivingLicense ?? unspec;
        public DateTime RegistrationDate => Data?.RegistrationDate ?? default;
        public bool IsDrivingLicenseValid => Data?.IsDrivingLicenseValid ?? default;
        public string BankCardID => Data?.BankCardID ?? unspec;
        public ICollection<Order> Order => orders.Value;
        public Lazy<ICollection<Order>> orders { get; }
        public BankCard BankcCard => bankCard.Value;
        public Lazy<BankCard> bankCard { get; }
        public AccessType AccessType => accessType.Value;
        public Lazy<AccessType> accessType { get; }
    }
}
