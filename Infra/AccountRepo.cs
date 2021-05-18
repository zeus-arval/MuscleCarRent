using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Repos;
using Infra.Common;
using MuscleCarRent.Data;
using MuscleCarRentProject.Data;

namespace Infra
{
    public sealed class AccountRepo : PagedRepo<Account, AccountData>, IAccountsRepo
    {
        public AccountRepo() : this(null) {}
        public AccountRepo(MuscleCarRentDBContext c) : base(c, c?.Accounts){}
        protected internal override Account toEntity(AccountData d) => new(d);
        protected internal override AccountData toData(Account e) => e?.Data ?? new AccountData();
        public List<Account> GetByAccessTypeID(string ID)
            => getRelated(x => x.AccessTypeID == ID);

    }
}
