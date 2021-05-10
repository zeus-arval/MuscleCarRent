using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MuscleCarRent.Data;
using MuscleCarRentProject.Core;
using MuscleCarRentProject.Domain.Repos;

namespace MuscleCarRentProject.Pages.Common
{
    public abstract class PagedPage<TEntity, TView> : OrderedPage<TEntity, TView>
    where TEntity : class, IBaseEntity, new()
    where TView : class, IEntityData, new()
    {
        protected PagedPage(IRepo<TEntity> r, MuscleCarRentDBContext c = null) : base(r, c){}
        public override bool HasNextPage => repo.HasNextPage;
        public override bool HasPreviousPage => repo.HasPreviousPage;

        public override int? PageIndex
        {
            get => repo.PageIndex;
            set => repo.PageIndex = value;
        }
    }
}
