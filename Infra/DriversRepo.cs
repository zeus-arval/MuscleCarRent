using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Contoso.Infra.Common;
using Domain;
using Domain.Repos;
using MuscleCarRentProject.Data;
using MuscleCarRentProject.Infra;

namespace Infra
{
    public sealed class DriversRepo : PagedRepo<Driver, DriverData>, IDriversRepo
    {
        public DriversRepo() : this(null){}
        public DriversRepo(MuscleCarRentDBContext c) : base(c, c?.Drivers){}
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
