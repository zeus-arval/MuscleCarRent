using System.Linq;
using Domain;
using Domain.Repos;
using Infra.Common;
using MuscleCarRentProject.Data;
using MuscleCarRentProject.Infra;

namespace Infra
{
    public sealed class PromotionRepo : PagedRepo<Promotion, PromotionData>, IPromotionRepo
    {
        public PromotionRepo() : this(null) { }
        public PromotionRepo(MuscleCarRentDBContext c) : base(c, c?.Promotions) { }
        protected internal override Promotion toEntity(PromotionData d)
            => new(d);
        protected internal override PromotionData toData(Promotion e)
            => e?.Data ?? new PromotionData();

        protected internal override IQueryable<PromotionData> applyFilters(IQueryable<PromotionData> query)
        {
            if (SearchString is null) return query;
            return query.Where(
                x => x.Discount.ToString().Contains(SearchString) ||
                     x.PromotionTypeEnum.ToString().Contains(SearchString) ||
                     x.TotalPrice.ToString().Contains(SearchString) ||
                     x.AccountID.Contains(SearchString) ||
                     x.CarID.Contains(SearchString));
        }
    }
}
