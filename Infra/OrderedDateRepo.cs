using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Repos;
using Infra.Common;
using MuscleCarRent.Data;
using MuscleCarRentProject.Data;
using MuscleCarRentProject.Domain.Repos;

namespace Infra
{
    public sealed class OrderedDateRepo : PagedRepo<OrderedDate, OrderedDateData>, IOrderedDatesRepo
    {
        public OrderedDateRepo() : this(null) { }
        public OrderedDateRepo(MuscleCarRentDBContext c) : base(c, c?.OrderedDates){}

        protected internal override OrderedDate toEntity(OrderedDateData d) => new(d);
        protected internal override OrderedDateData toData(OrderedDate e) => e?.Data ?? new OrderedDateData();
        public ICollection<OrderedDate> GetByCarID(string ID)
            => getRelated(x => x.CarID == ID);
        protected internal override IQueryable<OrderedDateData> applyFilters(IQueryable<OrderedDateData> query)
        {
            if (SearchString is null) return query;
            return query.Where(x => x.CarModel.Contains(SearchString));
        }
    }
}
