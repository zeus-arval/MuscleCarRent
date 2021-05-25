using System.Collections.Generic;
using System.Linq;
using Domain.Repos;
using Infra.Common;
using MuscleCarRentProject.Data;
using MuscleCarRentProject.Infra;

namespace Infra
{
    public sealed class AccountRepo : PagedRepo<Account, AccountData>, IAccountsRepo
    {
        public AccountRepo() : this(null) {}
        public AccountRepo(MuscleCarRentDBContext c) : base(c, c?.Accounts){}
        protected internal override Account toEntity(AccountData d) => new(d);
        protected internal override AccountData toData(Account e) => e?.Data ?? new AccountData();
        public List<Account> GetByAccessTypeId(string Id)
            => getRelated(x => x.AccessTypeId == Id);

        protected internal override IQueryable<AccountData> applyFilters(IQueryable<AccountData> query)
        {
            if (SearchString is null) return query;
            return query.Where(
                x => x.FirstName.Contains(SearchString) ||
                     x.LastName.Contains(SearchString) ||
                     x.Username.Contains(SearchString)
            );
        }
    }
}
