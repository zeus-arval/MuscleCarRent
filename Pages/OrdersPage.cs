﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Repos;
using Facade;
using Infra;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MuscleCarRent.Data;
using MuscleCarRentProject.Aids;
using MuscleCarRentProject.Data;
using MuscleCarRentProject.Pages.Common;

namespace MuscleCarRentProject.Pages
{
    public class OrdersPage : ViewPage<Order, OrderView>
    {
        public override string PageTitle => "Orders";
        public OrdersPage(MuscleCarRentDBContext c) : this(new OrderRepo(c), c) {}
        protected internal OrdersPage(IOrdersRepo r, MuscleCarRentDBContext c = null) : base(r, c){}
        protected internal override OrderView ToViewModel(Order o)
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
                "ID", "LastName", Item?.AccountID);
        public SelectList Cars =>
            new(context.Cars.OrderBy(x => x.Brand).ThenBy(x => x.Model).AsNoTracking(),
                "ID", "Brand", Item?.CarID);//THENBY Может вызвать ошибку

    }
}
