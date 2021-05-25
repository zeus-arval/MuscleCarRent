using MuscleCarRentProject.Core;
using MuscleCarRentProject.Domain.Repos;
using MuscleCarRentProject.Infra;

namespace MuscleCarRentProject.Pages.Common
{
    public abstract class FilteredPage<TEntity, TView> : CrudPage<TEntity, TView>
    where TEntity : class, IBaseEntity, new()
    where TView : class, IEntityData, new() 
    {
        protected FilteredPage(IRepo<TEntity> r, MuscleCarRentDBContext c = null) : base(r, c){ }

        public override string CurrentFilter { 
            get => repo.CurrentFilter;
            set => repo.CurrentFilter = value;

        }

        public override string SearchString
        {
            get => repo.SearchString; 
            set => repo.SearchString = value;
        }
    }
}
