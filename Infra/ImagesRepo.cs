using System.Collections.Generic;
using System.Linq;
using Contoso.Infra.Common;
using Domain;
using Domain.Repos;
using MuscleCarRentProject.Data;
using MuscleCarRentProject.Infra;

namespace Infra
{
    public sealed class ImagesRepo : PagedRepo<Image, ImageData>, IImagesRepo
    {
        public ImagesRepo() : this(null){}
        public ImagesRepo(MuscleCarRentDBContext c) : base(c, c?.Images){}
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
