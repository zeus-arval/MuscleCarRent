using System.Linq;
using Domain;
using Domain.Repos;
using Infra.Common;
using MuscleCarRentProject.Data;
using MuscleCarRentProject.Infra;
using System.Collections.Generic;

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
        public ICollection<Promotion> GetByAccountId(string Id)
            => getRelated(x => x.AccountId == Id);
        public ICollection<Promotion> GetByCarId(string Id) 
            => getRelated(x => x.CarId == Id);
        protected internal override IQueryable<PromotionData> applyFilters(IQueryable<PromotionData> query)
        {
            if (SearchString is null) return query;
            return query.Where(
                x => x.Discount.ToString().Contains(SearchString) ||
                     x.AccountFullName.Contains(SearchString) ||
                     x.CarModel.Contains(SearchString));
        }
    }
}
