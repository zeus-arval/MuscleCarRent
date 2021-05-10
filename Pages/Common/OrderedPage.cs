using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuscleCarRent.Data;
using MuscleCarRentProject.Core;
using MuscleCarRentProject.Domain.Repos;

namespace MuscleCarRentProject.Pages.Common
{
    public abstract class OrderedPage<TEntity, TView> : FilteredPage<TEntity,TView>
    where TEntity : class, IBaseEntity, new()
    where TView : class, IEntityData, new()
    {
        protected OrderedPage(IRepo<TEntity> r, MuscleCarRentDBContext c = null):base(r, c){}

        public override string SortOrder
        {
            get => repo.SortOrder;
            set => repo.SortOrder = value;
        }

        public override string CurrentSort => repo.CurrentSort;
    }
}
