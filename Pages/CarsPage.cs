using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infra;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MuscleCarRent.Data;
using MuscleCarRentProject.Aids;
using MuscleCarRentProject.Data;
using MuscleCarRentProject.Domain;
using MuscleCarRentProject.Domain.Repos;
using MuscleCarRentProject.Facade;
using MuscleCarRentProject.Pages.Common;

namespace MuscleCarRentProject.Pages
{
    public class CarsPage : ViewPage<Car, CarView>
    {
        public override string PageTitle => "Cars";
        public CarsPage(MuscleCarRentDBContext c) : this(new CarsRepo(c), c){}
        protected internal CarsPage(ICarsRepo r, MuscleCarRentDBContext c) : base(r, c){}

        protected internal override CarView ToViewModel(Car c)
        {
            if (IsNull(c)) return null;
            var view = Copy.Members(c.Data, new CarView());
            view.Brand = c.Brand;
            view.BodyType = c.BodyType;
            view.Color = c.Color;
            view.CarTypeName = c.CarType?.RentType.ToString();
            view.DriverName = c.Driver?.FullName;
            return view;
        }
        protected internal override Car toEntity(CarView v)
        {
            var car = Copy.Members(v, new CarData());
            return new Car(car);
        }
        public SelectList Drivers
            => new(context.Drivers.OrderBy(x => x.FirstName).AsNoTracking(),
                "id", "Name", Item?.DriverID);
        public SelectList CarTypes
            => new(context.CarTypes.OrderBy(x => x.RentTypeEnum).AsNoTracking(),
                "id", "Name", Item?.CarTypeID);
    }
}
