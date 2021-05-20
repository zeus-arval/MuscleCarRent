using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Repos;
using Infra.Common;
using MuscleCarRentProject.Data;
using MuscleCarRentProject.Infra;

namespace Infra
{
    public sealed class DriverRepo : PagedRepo<Driver, DriverData>, IDriversRepo
    {
        public DriverRepo() : this(null){}
        public DriverRepo(MuscleCarRentDBContext c) : base(c, c?.Drivers){}
        protected internal override Driver toEntity(DriverData d)
            => new(d);
        protected internal override DriverData toData(Driver e)
            => e?.Data ?? new DriverData();
        protected internal override IQueryable<DriverData> applyFilters(IQueryable<DriverData> query)
        {
            if (SearchString is null) return query;
            return query.Where(
               x => x.FirstName.Contains(SearchString) ||
                    x.LastName.Contains(SearchString));
        }
    }
}
