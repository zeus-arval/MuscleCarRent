using MuscleCarRentProject.Core;
using MuscleCarRentProject.Domain.Repos;
using MuscleCarRentProject.Infra;

namespace MuscleCarRentProject.Pages.Common
{
    public abstract class PagedPage<TEntity, TView> : OrderedPage<TEntity, TView>
    where TEntity : class, IBaseEntity, new()
    where TView : class, IEntityData, new()
    {
        protected PagedPage(IRepo<TEntity> r, MuscleCarRentDBContext c = null) : base(r, c) { }
        public override bool HasNextPage => repo.HasNextPage;
        public override bool HasPreviousPage => repo.HasPreviousPage;

        public override int? PageIndex
        {
            get => repo.PageIndex;
            set => repo.PageIndex = value;
        }
    }
}
