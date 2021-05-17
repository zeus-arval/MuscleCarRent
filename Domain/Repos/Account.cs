using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuscleCarRentProject.Data;
using MuscleCarRentProject.Domain.Common;

namespace Domain.Repos
{
    public class Account : BaseEntity<AccountData>
    {
        public Account() : this(null){}

        public Account(AccountData a) : base(a)
        {
            bankCard = getLazy<BankCard, IBankCardRepo>(b => b.Get(ID));
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
        public BankCard BankcCard => bankCard.Value;
        public Lazy<BankCard> bankCard { get; }
    }
}
