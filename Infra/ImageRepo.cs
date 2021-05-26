using System.Collections.Generic;
using System.Linq;
using Domain;
using Domain.Repos;
using Infra.Common;
using MuscleCarRentProject.Data;
using MuscleCarRentProject.Infra;

namespace Infra
{
    public sealed class ImageRepo : PagedRepo<Image, ImageData>, IImagesRepo
    {
        public ImageRepo() : this(null){}
        public ImageRepo(MuscleCarRentDBContext c) : base(c, c?.Images){}
        protected internal override Image toEntity(ImageData d)
            => new(d);
        protected internal override ImageData toData(Image e)
            => e?.Data ?? new ImageData();
        public List<Image> GetByCarId(string ID)
            => getRelated(x => x.CarId == ID);
        protected internal override IQueryable<ImageData> applyFilters(IQueryable<ImageData> query)
        {
            if (SearchString is null) return query;
            return query.Where(
                x => x.CarModel.Contains(SearchString));
        }
    }
}
