using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Repos;
using Facade;
using Infra;
using MuscleCarRentProject.Aids;
using MuscleCarRentProject.Data;
using MuscleCarRentProject.Domain.Repos;
using MuscleCarRentProject.Infra;
using MuscleCarRentProject.Pages.Common;

namespace MuscleCarRentProject.Pages
{
    public class DriversPage : ViewPage<Driver, DriverView>
    {
        public override string PageTitle => "Drivers";
        public DriversPage(MuscleCarRentDBContext c) : this(new DriverRepo(c), c){}
        public DriversPage(IRepo<Driver> r, MuscleCarRentDBContext c = null) : base(r, c) { }

        protected internal override Driver toEntity(DriverView v)
        {
            if (IsNull(v)) return null;
            var d = Copy.Members(v, new DriverData());
            if (string.IsNullOrEmpty(v.PersPhoto?.FileName)) return new Driver(d);
            var stream = new MemoryStream();
            v.PersPhoto?.CopyTo(stream);
            if (stream.Length < 2097152) d.Photo = stream.ToArray();
            return new Driver(d);
        }
        protected internal override DriverView toViewModel(Driver e)
        {
            if (IsNull(e)) return null;
            var v = Copy.Members(e.Data, new DriverView());
            return v;
        }
    }
}
