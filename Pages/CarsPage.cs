using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        protected internal override CarView toViewModel(Car c)
        {
            if (IsNull(c)) return null;
            var view = Copy.Members(c.Data, new CarView());
            view.
            return view;
        }

        protected internal override Car toEntity(CarView view)
        {
            var car = Copy.Members(view, new CarData());
            return new Car(car);
        }
        public SelectList 
    }
}
