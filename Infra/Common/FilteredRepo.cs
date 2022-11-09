﻿using MuscleCarRentProject.Core;
using MuscleCarRentProject.Data.Common;
using MuscleCarRentProject.Domain.Repos;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Data.Common;

namespace Contoso.Infra.Common
{
    public abstract class FilteredRepo<TEntity, TData> : CrudRepo<TEntity, TData>, IFilteredRepo
        where TData : BaseData, IEntityData, new()
    {
        private string currentFilter;
        private string searchString;
        protected FilteredRepo(DbContext c = null, DbSet<TData> s = null) : base(c, s) { }
        protected internal override IQueryable<TData> createSql() => applyFilters(base.createSql());
        protected internal virtual IQueryable<TData> applyFilters(IQueryable<TData> query) => query;

        public virtual int? PageIndex { get; set; }

        public virtual string CurrentFilter
        {
            get => currentFilter;
            set => setFilter(value, searchString);
        }
        public virtual string SearchString
        {
            get => searchString;
            set => setFilter(currentFilter, value);
        }
        protected internal virtual void setFilter(string curFilter, string searchStr)
        {
            setPageIndex(searchStr);
            setSearchString(curFilter, searchStr);
            setCurrentFilter(searchStr);
        }
        protected internal virtual void setCurrentFilter(string searchStr)
            => currentFilter = searchStr;
        protected internal virtual void setSearchString(string curFilter, string searchStr)
            => searchString = searchStr ?? curFilter;
        protected internal virtual void setPageIndex(string searchStr)
            => PageIndex = (searchStr == null) ? PageIndex : 1;
    }
}