using MuscleCarRentProject.Core;
using MuscleCarRentProject.Domain.Repos;
using MuscleCarRentProject.Infra;

namespace MuscleCarRentProject.Pages.Common
{
    public abstract class OrderedPage<TEntity, TView> : FilteredPage<TEntity,TView>
    where TEntity : class, IBaseEntity, new()
    where TView : class, IEntityData, new()
    {
        protected OrderedPage(IRepo<TEntity> r, MuscleCarRentDBContext c = null):base(r, c){}

        public override string SortOrder
        {
            get => repo.sortOrder;
            set => repo.sortOrder = value;
        }

        public override string CurrentSort => repo.currentSort;
    }
}
