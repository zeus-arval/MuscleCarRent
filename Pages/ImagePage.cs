﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Repos;
using Facade;
using Infra;
using MuscleCarRent.Data;
using MuscleCarRentProject.Aids;
using MuscleCarRentProject.Data;
using MuscleCarRentProject.Pages.Common;

namespace MuscleCarRentProject.Pages
{
    public class ImagePage : ViewPage<Image, ImageView>
    {
        public override string PageTitle => "Images";
        public ImagePage(MuscleCarRentDBContext c) : this(new ImageRepo(c), c){}
        protected internal ImagePage(IImagesRepo r , MuscleCarRentDBContext c = null) : base(r, c) {}

        protected internal override ImageView ToViewModel(Image e)
        {
            if (IsNull(e)) return null;
            var v = Copy.Members(e.Data, new ImageView());
            var photo = Convert.ToBase64String(e.Data.Image ?? Array.Empty<byte>(), 0, e.Data.Image?.Length ?? 0);
            v.PhotoAsString = "data:image/jpg;base64," + photo;
            return v;
        }

        protected internal override Image toEntity(ImageView e)
        {
            if (IsNull(e)) return null;
            var d = Copy.Members(ViewData, new ImageData());
            if (string.IsNullOrEmpty(e.Photo?.FileName)) return new Image(d);
            var stream = new MemoryStream();
            e.Photo?.CopyTo(stream);
            if (stream.Length < 2097152) d.Image = stream.ToArray();
            return new Image(d);
        }
    }
}
