using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Internal;
using MuscleCarRentProject.Aids;
using MuscleCarRentProject.Core;
using MuscleCarRentProject.Domain.Common;
using MuscleCarRentProject.Domain.Repos;

namespace MuscleCarRentProject.Domain.Common
{
    public abstract class BaseEntity<TData> :IBaseEntity
    where TData : class, IEntityData, new()
    {
        protected readonly TData data;
        protected BaseEntity() :this(null){}
        protected BaseEntity(TData d) => data = d;
        public TData Data => Copy.Members(data, new TData()) ?? new TData();
        public string Id => Data?.Id ?? "Unspecified";
        public byte[] RowVersion => Data?.RowVersion ?? Array.Empty<byte>();

        internal static Lazy<ICollection<TEntity>> getLazy<TEntity, TRepo>(Func<TRepo, ICollection<TEntity>> func)
            where TEntity : IBaseEntity where TRepo : IRepo<TEntity>
            => new(() => func(getRepo<TRepo>()));

        internal static Lazy<TEntity> getLazy<TEntity, TRepo>(Func<TRepo, TEntity> func)
            where TEntity : IBaseEntity where TRepo : IRepo<TEntity>
            => new(() => func(getRepo<TRepo>()));

        private static TRepo getRepo<TRepo>() => new GetRepo().Instance<TRepo>();
    }
}
