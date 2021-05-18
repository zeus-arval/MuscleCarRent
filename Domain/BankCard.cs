using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Repos;
using MuscleCarRentProject.Data;
using MuscleCarRentProject.Domain.Common;

namespace Domain
{
    public class BankCard :BaseEntity<BankCardData>
    {
        public BankCard() : this(null) {}

        public BankCard(BankCardData b) : base(b)
        {
            account = getLazy<Account, IAccountsRepo>(a => a.GetByID(ID));
        }
        public long CardNumber => Data?.CardNumber ?? default;
        public string CardHolderFullName => Data?.CardHolderFullName ?? unspec;
        public DateTime ExpirationTime => Data?.ExpirationTime ?? default;
        public short CVV => Data?.CVV ?? default;
        public string AccountID => Data?.AccountID ?? unspec;
        public Account Account => account.Value;
        public Lazy<Account> account { get; }
    }
}
