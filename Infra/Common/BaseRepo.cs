using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Core;
using Data.Common;
using Microsoft.AspNetCore.Mvc.DataAnnotations.Internal;
using Microsoft.EntityFrameworkCore;
using MuscleCarRentProject.Core;
using MuscleCarRentProject.Domain.Repos;

namespace Infra.Common
{
    public abstract class BaseRepo<TEntity, TData> : BaseRepo<TData>, IRepo<TEntity> 
        where TData : BaseData, IEntityData, new()
    {
        protected internal abstract TEntity toEntity(TData d);
        protected internal abstract TData toData(TEntity e);
        protected BaseRepo( DbContext c = null, DbSet<TData> s = null) : base(c, s){}
        public new TEntity EntityInDb => toEntity(base.EntityInDb);
        public async new Task<List<TEntity>> Get() => (await base.Get()).Select(toEntity).ToList();
        public async new Task<TEntity> Get(string id) => toEntity(await base.Get(id));
        public virtual async Task<bool> Delete(TEntity e) => await Delete(toData(e));
        public virtual async Task<bool> Add(TEntity e) => await Add(toData(e));
        public virtual async Task<bool> Update(TEntity e) => await Update(toData(e));
        public new TEntity GetByID(string id) => toEntity(base.GetByID(id));
    }

    public abstract class BaseRepo<T> : IRepo<T> where T : BaseData, IEntityData, new()
    {
        protected internal readonly DbSet<T> dBSet;
        protected internal readonly DbContext context;
        public string ErrorMessage { get; protected set; }
        public T EntityInDb { get; protected set; }
        protected BaseRepo(DbContext c = null, DbSet<T> s = null) => (dBSet, context) = (s, c);
        public async Task<List<T>> Get() => await createSQL().ToListAsync();
        protected internal virtual IQueryable<T> createSQL() => dBSet.AsNoTracking();

        public async Task<T> Get(String id)
        {
            if (id is null) return null;
            if (dBSet is null) return null;
            return await dBSet.AsNoTracking().FirstOrDefaultAsync(m => m.ID == id);
        }

        public async Task<bool> Delete(T obj)
        {
            var isOk = await isEntityOk(obj, ErrorMessages.ConcurrencyOnDelete);
            if (isOk) dBSet.Remove(obj);
            await context.SaveChangesAsync();
            return isOk;
        }
        public async Task<bool> Add(T obj)
        {
            var isOk = await isEntityOk(obj, true);
            if (isOk) await dBSet.AddAsync(obj);
            await context.SaveChangesAsync();
            return isOk;
        }
        public async Task<bool> Update(T obj)
        {
            var isOk = await isEntityOk(obj, ErrorMessages.ConcurrencyOnEdit);
            if (isOk) dBSet.Update(obj);
            await context.SaveChangesAsync();
            return isOk;
        }
        public T GetByID(string id) => Get(id).GetAwaiter().GetResult();
        internal static bool byteArrayCompare(ReadOnlySpan<byte> a1, ReadOnlySpan<byte> a2)
            => a1.SequenceEqual(a2);
        public bool errorMessage(string msg)
        {
            ErrorMessage = msg;
            return false;
        }
        public async Task<bool> isEntityOk(T obj, string concurrencyErrorMsg) =>
            await isEntityOk(obj, false) && isCorrectVersion(obj, concurrencyErrorMsg);

        public async Task<bool> isEntityOk(T obj, bool isNewItem)
        {
            if (obj is null) return errorMessage("Item is null");
            if (dBSet is null) return errorMessage("DbSet is null");
            EntityInDb = await Get(obj.ID);
            return (EntityInDb is null) == isNewItem ||
                   errorMessage(isNewItem 
                       ? $"Item with id = <{obj.ID}> already in database" 
                       : $"No item with id = <{obj.ID}> in database");
        }

        internal bool isCorrectVersion(T obj, string concurrencyErrorMsg) =>
            byteArrayCompare(obj.RowVersion, EntityInDb?.RowVersion) || errorMessage(concurrencyErrorMsg);

        public abstract int? PageIndex { get; set; }
        public abstract int TotalPages { get; }
        public abstract bool HasNextPage { get; }
        public abstract bool HasPreviousPage { get; }
        public abstract int PageSize { get; set; }
        public abstract string CurrentFilter { get; set; }
        public abstract string SearchString { get; set; }
        public abstract string SortOrder { get; set; }
        public abstract string CurrentSort { get; set; }
    }
}
