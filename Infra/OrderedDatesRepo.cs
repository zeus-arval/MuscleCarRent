﻿using System.Collections.Generic;
using System.Linq;
using Contoso.Infra.Common;
using Domain;
using Domain.Repos;
using MuscleCarRentProject.Data;
using MuscleCarRentProject.Infra;

namespace Infra
{
    public sealed class OrderedDatesRepo : PagedRepo<OrderedDate, OrderedDateData>, IOrderedDatesRepo
    {
        public OrderedDatesRepo() : this(null) { }
        public OrderedDatesRepo(MuscleCarRentDBContext c) : base(c, c?.OrderedDates){}
        protected internal override OrderedDate toEntity(OrderedDateData d) => new(d);
        protected internal override OrderedDateData toData(OrderedDate e) => e?.Data ?? new OrderedDateData();
        public ICollection<OrderedDate> GetByCarId(string ID)
            => getRelated(x => x.CarId == ID);
        protected internal override IQueryable<OrderedDateData> applyFilters(IQueryable<OrderedDateData> query)
        {
            if (SearchString is null) return query;
            return query.Where(
                x => x.CarModel.Contains(SearchString) ||
                     x.OrderDate.ToString().Contains(SearchString));
        }
    }
}
