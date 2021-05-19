using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Facade;
using Infra;
using MuscleCarRent.Data;
using MuscleCarRentProject.Aids;
using MuscleCarRentProject.Data;
using MuscleCarRentProject.Domain.Repos;
using MuscleCarRentProject.Pages.Common;

namespace MuscleCarRentProject.Pages
{
    public class PromotionsPage : ViewPage<Promotion, PromotionView>
    {
        public override string PageTitle => "Promotions";
        public PromotionsPage(MuscleCarRentDBContext c) : this(new PromotionRepo(c), c){}
        protected internal PromotionsPage(IRepo<Promotion> r, MuscleCarRentDBContext c) : base(r, c){}

        protected internal override Promotion toEntity(PromotionView v)
        {
            if (IsNull(v)) return null;
            var d = Copy.Members(v, new PromotionData());
            return new Promotion(d);
        }

        protected internal override PromotionView ToViewModel(Promotion e)
        {
            if (IsNull(e)) return null;
            var v = Copy.Members(e.Data, new PromotionView());
            return v;
        }
    }
}
