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
    public class PromotionPage : ViewPage<Promotion, PromotionData>
    {
        public override string PageTitle => "Promotions";
        public PromotionPage(MuscleCarRentDBContext c) : this(new PromotionRepo(c), c){}
        protected internal PromotionPage(IRepo<Promotion> r, MuscleCarRentDBContext c) : base(r, c){}

        protected internal override Promotion toEntity(PromotionData e)
        {
            if (IsNull(e)) return null;
            var d = Copy.Members(e, new PromotionData());
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
