using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Facade;
using Infra;
using MuscleCarRent.Data;
using MuscleCarRentProject.Aids;
using MuscleCarRentProject.Data;
using MuscleCarRentProject.Domain.Repos;
using MuscleCarRentProject.Pages.Common;

namespace MuscleCarRentProject.Pages
{
    public class DriverPage : BasePage<Driver, DriverView>
    {
        public override string PageTitle => "Drivers";
        public DriverPage(MuscleCarRentDBContext c) : this(new DriverRepo(c), c){}
        public DriverPage(IRepo<Driver> r, MuscleCarRentDBContext c = null) : base(r, c) { }

        protected internal override Driver toEntity(DriverView e)
        {
            if (IsNull(e)) return null;
            var d = Copy.Members(e, new DriverData());
            return new Driver(d);
        }
        protected internal override DriverView ToViewModel(Driver e)
        {
            if (IsNull(e)) return null;
            var v = Copy.Members(e.Data, new DriverView());
            return v;
        }
    }
}
