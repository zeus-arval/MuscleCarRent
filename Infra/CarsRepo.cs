using System.Collections.Generic;
using System.Linq;
using MuscleCarRentProject.Infra;
using Infra.Common;
using MuscleCarRentProject.Data;
using MuscleCarRentProject.Domain;
using MuscleCarRentProject.Domain.Repos;

namespace Infra
{
    public sealed class CarsRepo : PagedRepo<Car, CarData>, ICarsRepo
    {
        public CarsRepo(): this(null){}
        public CarsRepo(MuscleCarRentDBContext c) : base(c, c?.Cars) {}
        protected internal override Car toEntity(CarData data) => new(data);
        protected internal override CarData toData(Car e) => e?.Data ?? new CarData();
        public List<Car> GetByCarTypeId(string Id)
            => getRelated(x => x.CarTypeId == Id);
        public List<Car> GetByDriverId(string Id)
            => getRelated(x => x.DriverId == Id);
        protected internal override IQueryable<CarData> applyFilters(IQueryable<CarData> query)
        {
            if (SearchString is null) return query;
            return query.Where(
                x => x.Engine.Contains(SearchString) ||
                    x.ShortDescription.Contains(SearchString) ||
                    x.LongDescription.Contains(SearchString) ||
                    x.Model.Contains(SearchString) ||
                    x.Power.ToString().Contains(SearchString) ||
                    x.ProductionYear.ToString().Contains(SearchString)
            );
        }
    }
}
