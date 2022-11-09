using System;
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
        public AccountsPage(MuscleCarRentDBContext c) : this(new AccountsRepo(c), c) { }
        protected internal AccountsPage(IAccountsRepo r, MuscleCarRentDBContext c = null) : base(r, c) { }
        protected internal override AccountView toViewModel(Account a)
        {
            if (IsNull(a)) return null;
            string format = "data:image/jpg;base64,";
            var view = Copy.Members(a.Data, new AccountView());
            view.BankCardNumber = a.BankCard?.CardNumber.ToString() ?? string.Empty;
            view.PersonPhotoAsString = format + ConvertPhoto(a.Data?.PersonPhoto);
            view.BankCardNumber = a.BankCard?.CardNumber.ToString();
            view.AccessTypeName = a.AccessType?.AccessLevel.ToString();
            view.DrivingLicensePhotoAsString = format + ConvertPhoto(a.Data?.DrivingLicensePhoto);
            return view;
        }
        protected internal override Account toEntity(AccountView v)
        {
            if (IsNull(v)) return null;
            var d = Copy.Members(v, new AccountData());
            if (string.IsNullOrEmpty(v.PersonPhoto?.FileName)) return new Account(d);
            var stream = new MemoryStream();
            v.PersonPhoto?.CopyTo(stream);
            if (stream.Length < 2097152) d.PersonPhoto = stream.ToArray();
            if(string.IsNullOrEmpty(v.DLPhoto?.FileName)) return new Account(d);
            stream = new MemoryStream();
            v.PersonPhoto?.CopyTo(stream);
            if (stream.Length < 2097152) d.DrivingLicensePhoto = stream.ToArray();
            return new Account(d);
        }
        private static string ConvertPhoto(byte[] photo)
            => System.Convert.ToBase64String(photo ?? Array.Empty<byte>(), 0, photo?.Length ?? 0);

        public SelectList AccessTypes
        {
            get
            {
                var l = new GetRepo().Instance<IAccessTypesRepo>().Get();
                return new SelectList(l, "Id", "AccessType", Item?.AccessTypeId);
            }
        }
        public SelectList BankCards
        {
            get
            {
                var l = new GetRepo().Instance<IBankCardsRepo>().Get();
                return new SelectList(l, "Id", "CardNumber", Item?.BankCardId);
            }
        }
    }
}
