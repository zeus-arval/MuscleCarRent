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
            account = getLazy<Account, IAccountsRepo>(a => a.Get(Id));
        }
        public long CardNumber => Data?.CardNumber ?? default;
        public DateTime ExpirationTime => Data?.ExpirationTime ?? default;
        public short CVV => Data?.CVV ?? default;
        
        public string CardHolderFullName => Account?.FullName ?? string.Empty;
        public string AccountId => Data?.AccountId ?? string.Empty;
        public Account Account => account.Value;
        public Lazy<Account> account { get; }
    }
}
