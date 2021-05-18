using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MuscleCarRent.Data;
using MuscleCarRentProject.Core;
using MuscleCarRentProject.Domain.Repos;

namespace MuscleCarRentProject.Pages.Common
{
    public abstract class ViewPage<TEntity, TView> : PagedPage<TEntity, TView>
        where TEntity : class, IBaseEntity, new()
        where TView : class, IEntityData, new()
    {
        protected ViewPage(IRepo<TEntity> r, MuscleCarRentDBContext context = null) : base(r, context){}

        public virtual async Task<IActionResult> OnGetIndexAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            (PageIndex, SearchString, CurrentFilter, SortOrder) = (pageIndex, searchString, currentFilter, sortOrder);
            Items = (await repo.Get()).Select(ToViewModel).ToList();
            return Page();
        }
    }
}
