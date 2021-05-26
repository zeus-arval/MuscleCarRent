using System.IO;
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
    public class AccountsPage : ViewPage<Account, AccountView>
    {
        public override string PageTitle => "Accounts";
        public AccountsPage(MuscleCarRentDBContext c) : this(new AccountRepo(c), c) { }
        protected internal AccountsPage(IAccountsRepo r, MuscleCarRentDBContext c = null) : base(r, c) { }
        protected internal override AccountView toViewModel(Account a)
        {
            if (IsNull(a)) return null;
            var view = Copy.Members(a.Data, new AccountView());
            view.BankCardNumber = a.BankCard?.CardNumber.ToString();
            return view;
        }
        protected internal override Account toEntity(AccountView v)
        {
            var d = Copy.Members(v, new AccountData());
            if (string.IsNullOrEmpty(v.Photo?.FileName)) return new Account(d);
            var stream = new MemoryStream();
            v.Photo?.CopyTo(stream);
            if (stream.Length < 2097152) d.Photo = stream.ToArray();
            return new Account(d);
        }

        public SelectList AccessTypes
        {
            get
            {
                var l = new GetRepo().Instance<IAccessTypesRepo>().Get();
                return new SelectList(l, "Id", "Name", Item?.AccessTypeId);
            }
        }
    }
}
