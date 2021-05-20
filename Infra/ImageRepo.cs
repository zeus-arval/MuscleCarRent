﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Repos;
using Infra.Common;
using MuscleCarRent.Data;
using MuscleCarRentProject.Data;

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
        public List<Image> GetByCarID(string ID)
            => getRelated(x => x.CarID == ID);
        protected internal override IQueryable<ImageData> applyFilters(IQueryable<ImageData> query)
        {
            if (SearchString is null) return query;
            return query.Where(
                x => x.CarID.Contains(SearchString));
        }
    }
}