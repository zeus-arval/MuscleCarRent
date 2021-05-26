using System;
using System.IO;
using Domain;
using Domain.Repos;
using Facade;
using Infra;
using Microsoft.AspNetCore.Mvc.Rendering;
using MuscleCarRentProject.Aids;
using MuscleCarRentProject.Data;
using MuscleCarRentProject.Domain.Common;
using MuscleCarRentProject.Domain.Repos;
using MuscleCarRentProject.Infra;
using MuscleCarRentProject.Pages.Common;

namespace MuscleCarRentProject.Pages
{
    public class ImagesPage : ViewPage<Image, ImageView>
    {
        public override string PageTitle => "Images";
        public ImagesPage(MuscleCarRentDBContext c) : this(new ImageRepo(c), c){}
        protected internal ImagesPage(IImagesRepo r , MuscleCarRentDBContext c = null) : base(r, c) {}

        protected internal override ImageView toViewModel(Image e)
        {
            if (IsNull(e)) return null;
            var v = Copy.Members(e.Data, new ImageView());
            var photo = Convert.ToBase64String(e.Data.Image ?? Array.Empty<byte>(), 0, e.Data.Image?.Length ?? 0);
            v.CarPhotoAsString = "data:image/jpg;base64," + photo;
            return v;
        }

        protected internal override Image toEntity(ImageView v)
        {
            if (IsNull(v)) return null;
            var d = Copy.Members(ViewData, new ImageData());
            if (string.IsNullOrEmpty(v.Photo?.FileName)) return new Image(d);
            var stream = new MemoryStream();
            v.Photo?.CopyTo(stream);
            if (stream.Length < 2097152) d.Image = stream.ToArray();
            return new Image(d);
        }

        public SelectList Cars
        {
            get
            {
                var l = new GetRepo().Instance<ICarsRepo>().Get();
                return new SelectList(l, "Id", "Model", Item?.CarId);
            }
        }
    }
}
