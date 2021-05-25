using System.Linq;
using Domain.Repos;
using Facade;
using Infra;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MuscleCarRentProject.Aids;
using MuscleCarRentProject.Data;
using MuscleCarRentProject.Infra;
using MuscleCarRentProject.Pages.Common;

namespace MuscleCarRentProject.Pages
{
    public class OrdersPage : ViewPage<Order, OrderView>
    {
        public override string PageTitle => "Orders";
        public OrdersPage(MuscleCarRentDBContext c) : this(new OrderRepo(c), c) {}
        protected internal OrdersPage(IOrdersRepo r, MuscleCarRentDBContext c = null) : base(r, c){}
        protected internal override OrderView toViewModel(Order o)
        {
            if (IsNull(o)) return null;
            var view = Copy.Members(o.Data, new OrderView());
            view.AccountName = o.Account?.FullName;
            view.CarModel = o.Car?.Model;
            return view;
        }
        protected internal override Order toEntity(OrderView v)
        {
            var e = Copy.Members(v, new OrderData());
            return new Order(e);
        }
        public SelectList Accounts =>
            new(context.Accounts.OrderBy(x => x.LastName).AsNoTracking(),
                "Id", "LastName", Item?.AccountId);
        public SelectList Cars =>
            new(context.Cars.OrderBy(x => x.Brand).ThenBy(x => x.Model).AsNoTracking(),
                "Id", "Brand", Item?.CarId);//THENBY Может вызвать ошибку

    }
}
