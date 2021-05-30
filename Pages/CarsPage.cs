using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Repos;
using Infra;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MuscleCarRentProject.Aids;
using MuscleCarRentProject.Data;
using MuscleCarRentProject.Domain;
using MuscleCarRentProject.Domain.Common;
using MuscleCarRentProject.Domain.Repos;
using MuscleCarRentProject.Facade;
using MuscleCarRentProject.Infra;
using MuscleCarRentProject.Pages.Common;

namespace MuscleCarRentProject.Pages
{
    public class CarsPage : ViewPage<Car, CarView>
    {
        public override string PageTitle => "Cars";
        public CarsPage(MuscleCarRentDBContext c) : this(new CarsRepo(c), c){}
        protected internal CarsPage(ICarsRepo r, MuscleCarRentDBContext c) : base(r, c){}
        protected internal override CarView toViewModel(Car c)
        {
            if (IsNull(c)) return null;
            var view = Copy.Members(c.Data, new CarView());
            view.Brand = c.Brand;
            view.BodyType = c.BodyType;
            view.Color = c.Color;
            view.CarTypeName = c.CarType?.RentType.ToString();
            view.DriverFullName = c.Driver?.FullName;
            return view;
        }
        protected internal override Car toEntity(CarView v)
        {
            var car = Copy.Members(v, new CarData());
            return new Car(car);
        }
        public SelectList Drivers
        {
            get
            {
                var l = new GetRepo().Instance<IDriversRepo>().Get();
                return new SelectList(l, "Id", "FullName", Item?.DriverId);
            }
        }
        public SelectList CarTypes
        {
            get
            {
                var l = new GetRepo().Instance<ICarTypesRepo>().Get();
                return new SelectList(l, "Id", "RentTypeName", Item?.CarTypeId);
            }
        }
        public SelectList Colors
        {
            get => new SelectList(Enum.GetValues(typeof(ColorEnum)));
        }
        public SelectList Brands
        {
            get => new SelectList(Enum.GetValues(typeof(BrandEnum)));
        }
        public SelectList BodyTypes
        {
            get => new SelectList(Enum.GetValues(typeof(BodyTypeEnum)));
        }
    }
}
