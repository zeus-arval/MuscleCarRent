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
using MuscleCarRentProject.Pages.Common;

namespace MuscleCarRentProject.Pages
{
    public class BankCardPage : ViewPage<BankCard, BankCardView>
    {
        public override string PageTitle => "BankCards";
        public BankCardPage(MuscleCarRentDBContext c) : this(new BankCardRepo(c), c){}
        protected internal BankCardPage(IBankCardsRepo r, MuscleCarRentDBContext c = null) : base(r, c){}
        protected internal override BankCardView ToViewModel(BankCard e)
        {
            if(IsNull(e)) return null;
            var v = Copy.Members(e.Data, new BankCardView());
            return v;
        }
        protected internal override BankCard toEntity(BankCardView e)
        {
            if (IsNull(e)) return null;
            var d = Copy.Members(e, new BankCardData());
            return new BankCard(d);
        }
    }
}
