using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Facade;
using Infra;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MuscleCarRentProject.Aids;
using MuscleCarRentProject.Data;
using MuscleCarRentProject.Domain.Repos;
using MuscleCarRentProject.Infra;
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

        protected internal override PromotionView toViewModel(Promotion e)
        {
            if (IsNull(e)) return null;
            var v = Copy.Members(e.Data, new PromotionView());
            return v;
        }
        public SelectList Accounts =>
            new(context.Accounts.OrderBy(x => x.LastName).AsNoTracking(),
                "Id", "LastName", Item?.AccountId);
        public SelectList Cars =>
            new(context.Cars.OrderBy(x => x.Brand).ThenBy(x => x.Model).AsNoTracking(),
                "Id", "Brand", Item?.CarId);//THENBY Может вызвать ошибку
        public SelectList Promotions
        {
            get => new SelectList(Enum.GetValues(typeof(PromotionTypeEnum)));
        }
    }
}
