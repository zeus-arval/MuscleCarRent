using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Data.Common;
using Microsoft.EntityFrameworkCore;
using MuscleCarRentProject.Core;

namespace Infra.Common
{
    public abstract class CrudRepo<TEntity, TData> : BaseRepo<TEntity, TData>
        where TData : BaseData, IEntityData, new()
    {
        protected CrudRepo(DbContext c = null, DbSet<TData> s = null) : base(c, s){}
        protected internal List<TEntity> getRelated(Expression<Func<TData, bool>> predicate) =>
            dBSet?
                .Where(predicate)
                .AsNoTracking()
                .AsEnumerable()
                .Select(toEntity)
                .ToList() ?? new List<TEntity>();
    }
}
