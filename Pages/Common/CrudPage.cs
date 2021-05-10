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
    public abstract class CrudPage<TEntity, TView> : BasePage<TEntity, TView>
        where TEntity : class, IBaseEntity, new()
        where TView : class, IEntityData, new()
    {
        protected CrudPage(IRepo<TEntity> r, MuscleCarRentDBContext c = null) : base(r, c) { }

        public IList<TView> Items { get; set; }
    }
}
