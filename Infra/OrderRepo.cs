using System.Collections.Generic;
using System.Linq;
using Domain.Repos;
using Infra.Common;
using MuscleCarRentProject.Data;
using MuscleCarRentProject.Infra;

namespace Infra
{
    public sealed class OrderRepo : PagedRepo<Order, OrderData>, IOrdersRepo
    {
        public OrderRepo() : this(null){}
        public OrderRepo(MuscleCarRentDBContext c) : base(c, c?.Orders){}
        protected internal override Order toEntity(OrderData o) => new(o);
        protected internal override OrderData toData(Order e) => e?.Data ?? new OrderData();
        public ICollection<Order> GetByCarID(string ID)
            => getRelated(x => x.CarID == ID);
        public ICollection<Order> GetByAccountID(string ID)
            => getRelated(x => x.AccountID == ID);

        protected internal override IQueryable<OrderData> applyFilters(IQueryable<OrderData> query)
        {
            if (SearchString is null) return query;
            return query.Where(
                x => x.OrderDate.ToString().Contains(SearchString) ||
                     x.RentDate.ToString().Contains(SearchString) ||
                     x.AccountID.Contains(SearchString)
            );
        }
    }
}
