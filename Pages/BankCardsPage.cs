﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Repos;
using Facade;
using Infra;
using Microsoft.AspNetCore.Mvc.Rendering;
using MuscleCarRentProject.Aids;
using MuscleCarRentProject.Data;
using MuscleCarRentProject.Domain.Common;
using MuscleCarRentProject.Infra;
using MuscleCarRentProject.Pages.Common;

namespace MuscleCarRentProject.Pages
{
    public class BankCardsPage : ViewPage<BankCard, BankCardView>
    {
        public override string PageTitle => "BankCards";
        public BankCardsPage(MuscleCarRentDBContext c) : this(new BankCardsRepo(c), c){}
        protected internal BankCardsPage(IBankCardsRepo r, MuscleCarRentDBContext c = null) : base(r, c){}
        protected internal override BankCardView toViewModel(BankCard e)
        {
            if(IsNull(e)) return null;
            var v = Copy.Members(e.Data, new BankCardView());
            v.CardHolderFullName = e.Account.FullName;
            return v;
        }
        protected internal override BankCard toEntity(BankCardView v)
        {
            if (IsNull(v)) return null;
            var d = Copy.Members(v, new BankCardData());
            return new BankCard(d);
        }
        public SelectList Accounts
        {
            get
            {
                var l = new GetRepo().Instance<IAccountsRepo>().Get();
                return new SelectList(l, "Id", "FullName", Item?.AccountId);
            }
        }
    }
}
