using System;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MuscleCarRent.Data;
using MuscleCarRentProject.Core;
using MuscleCarRentProject.Core.Extensions;
using MuscleCarRentProject.Domain.Repos;

namespace MuscleCarRentProject.Pages.Common
{
    public abstract class BasePage : PageModel, IBasePage
    {
        public string ErrorMessage { get; protected set; }
        public abstract string PageTitle { get; }
        public virtual string PageUrl => PageTitle;
        [BindProperty] public IEntityData Item { get; set; }
        public virtual string SortOrder { get; set; }
        public abstract string CurrentSort { get; }
        public virtual string CurrentFilter { get; set; }
        public virtual string SearchString { get; set; }
        public virtual bool HasPreviousPage { get; protected set; }
        public virtual bool HasNextPage { get; protected set; }
        public virtual int? PageIndex { get; set; }
    }

    public abstract class BasePage<TEntity, TView> : BasePage
        where TEntity : class, IBaseEntity, new()
        where TView : class, IEntityData, new()
    {
        protected readonly MuscleCarRentDBContext context;
        protected readonly IRepo<TEntity> repo;

        protected BasePage(IRepo<TEntity> r, MuscleCarRentDBContext c) =>
            (repo, context) = (r, c);

        [BindProperty] public new TView Item
        {
            get => (TView)base.item;
            set => base.item = value;
        }
        protected internal bool IsNull(object o) => o is null;
        protected internal string SetConcurrencyMsg(bool isError) => isError ? ErrorMessages.ConcurrencyOnDelete : null;
        protected internal virtual void DoOnCreate(){}
        protected internal abstract TView ToViewModel(TEntity e);
        protected internal abstract TEntity toEntity(TView e);
        protected internal virtual async Task GetRelatedItems(TEntity item) => await Task.CompletedTask;

        internal async Task<TView> GetItem(string id, bool concurrencyError = false)
        {
            var item = await repo.Get(id);
            await GetRelatedItems(item);
            ErrorMessage = SetConcurrencyMsg(concurrencyError);
            return ToViewModel(item);
        }

        internal async Task<bool> Remove()
            => !IsNull(repo) && await repo.Delete(toEntity(Item));
        internal async Task<bool> Add()
            => !IsNull(repo) && await repo.Add(toEntity(Item));
        internal async Task<bool> Update()
            => !IsNull(repo) && await repo.Update(toEntity(Item));

        internal async Task<TEntity> Find(string id)
            => !IsNull(id) ? null : IsNull(repo) ? null : await repo.Get(id);

        internal async Task<bool> Save(params Func<Task<bool>>[] actions)
        {
            var transaction = IsNull(context) ? null : await context.Database.BeginTransactionAsync();
            foreach (var action in actions)
            {
                var b = await action();
                if (b) continue;
                ErrorMessage = repo?.ErrorMessage;
                if (transaction != null) await transaction.RollbackAsync();
                return false;
            }
            if (!IsNull(context)) await context.SaveChangesAsync();
            if (transaction != null) await transaction.CommitAsync();
            return true;
        }
        protected internal virtual void DoBeforeCreate(TView v, string[] selectedArray = null) { }
        protected internal virtual void DoBeforeDelete(TView v) { }
        protected internal virtual void DoBeforeEdit(TView v, string[] selectedArray = null) { }

        internal IActionResult IndexPage()
            => RedirectToPage("./Index", new {handler = "Index"});

        public async Task<IActionResult> OnGetDeleteAsync(string id, bool concurrencyError = false)
            => IsNull(Item = await GetItem(id, concurrencyError)) ? NotFound() : Page();
        public async Task<IActionResult> OnGetDetailsAsync(string id)
            => IsNull(Item = await GetItem(id)) ? NotFound() : Page();

        public async Task<IActionResult> OnGetEditAsync(string id)
            => IsNull(Item = await GetItem(id)) ? NotFound() : Page();

        public IActionResult OnGetCreate()
        {
            DoOnCreate();
            return Page();
        }

        public virtual async Task<IActionResult> OnPostDeleteAsync(string id)
        {
            DoBeforeDelete(Item);
            if (await Save(Remove)) return IndexPage();
            if (repo?.EntityInDb is null) return IndexPage();
            return RedirectToPage("./Delete",
                new {id, concurrencyError = true, handler = "Delete"});
        }

        public virtual async Task<IActionResult> OnPostEditAsync(string id, string[] selectedArray = null)
        {
            if (!ModelState.IsValid) return Page();
            DoBeforeEdit(Item, selectedArray);
            if (await Save(Update)) return IndexPage();
            SetPreviousValue(ToViewModel(repo?.EntityInDb));
            Item.RowVersion = repo?.EntityInDb?.RowVersion;
            ModelState.Remove("Item.RowVersion");
            return Page();
        }

        public virtual async Task<IActionResult> OnPostCreateAsync(string[] selectedArray = null)
        {
            if (ModelState.IsValid) return Page();
            DoBeforeCreate(Item,selectedArray);
            if (await Save(Add)) return IndexPage();
            return Page();
        }
        private void SetPreviousValue(TView dBValues)
        {
            if (IsNull(dBValues)) return;
            foreach (var property in dBValues.GetType().GetProperties())
            {
                if(!property.CanRead) continue;
                var dBValue = property.GetValue(dBValues);
                var clientValue = property.GetValue(Item);
                if(dBValues?.ToString() == clientValue?.ToString()) continue;
                ModelState.TryAddModelError($"Item.{property.Name}",
                    $"Current value: {dBValue}");
            }
        }
    }
}
