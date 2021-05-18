using System;
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
    public class AccountPage : ViewPage<Account, AccountView>
    {
        public override string PageTitle => "Accounts";
        public AccountPage(MuscleCarRentDBContext c) : this(new AccountRepo(c), c) { }
        protected internal AccountPage(IAccountsRepo r, MuscleCarRentDBContext c = null) : base(r, c) { }
        protected internal override AccountView ToViewModel(Account a)
        {
            if (IsNull(a)) return null;
            var view = Copy.Members(a.Data, new AccountView());
            view.BankCardNumber = a.BankcCard?.CardNumber.ToString();
            return view;
        }

        protected internal override Account toEntity(AccountView e)
        {
            var a = Copy.Members(e, new AccountData());
            return new Account(a);
        }
    }
}
