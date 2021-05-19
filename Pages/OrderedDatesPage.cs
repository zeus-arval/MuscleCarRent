using System;
using System.Collections.Generic;
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
using MuscleCarRentProject.Domain.Repos;
using MuscleCarRentProject.Pages.Common;

namespace MuscleCarRentProject.Pages
{
    public class OrderedDatesPage : ViewPage<OrderedDate, OrderedDateView>
    {
        public override string PageTitle => "Ordered dates";
        public OrderedDatesPage(MuscleCarRentDBContext c) : this(new OrderedDateRepo(c), c){}
        protected internal OrderedDatesPage(IOrderedDatesRepo r, MuscleCarRentDBContext c) : base(r, c) {}
        protected internal override OrderedDateView ToViewModel(OrderedDate e)
        {
            if (IsNull(e)) return null;
            var view = Copy.Members(e.Data, new OrderedDateView());
            view.CarModel = e.Car?.Model;
            return view;
        }
        protected internal override OrderedDate toEntity(OrderedDateView v)
        {
            var d = Copy.Members(v, new OrderedDateData());
            return new OrderedDate(d);
        }
    }
}
