using System.Linq;
using Domain;
using Domain.Repos;
using Infra.Common;
using MuscleCarRentProject.Data;
using MuscleCarRentProject.Infra;

namespace Infra
{
    public sealed class BankCardRepo : PagedRepo<BankCard, BankCardData>, IBankCardsRepo
    {
        public BankCardRepo() : this(null){}
        public BankCardRepo(MuscleCarRentDBContext c) : base(c, c?.BankCards){}

        protected internal override BankCard toEntity(BankCardData d)
            => new(d);

        protected internal override BankCardData toData(BankCard e)
            => e?.Data ?? new BankCardData();

        protected internal override IQueryable<BankCardData> applyFilters(IQueryable<BankCardData> query)
        {
            if (SearchString is null) return query;
            return query.Where(
                x => x.CardHolderFullName.Contains(SearchString) ||
                     x.AccountId.Contains(SearchString));
        }
    }
}
