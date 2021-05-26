using System;
using MuscleCarRentProject.Domain.Common;
using MuscleCarRentProject.Core;
using MuscleCarRentProject.Data.Common;

namespace MuscleCarRentProject.Domain.Common
{
    public interface IPersonEntity : IBaseEntity
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string FullName { get; }
        public DateTime BirthDay { get; }
    }

    public abstract class Person<TData> : BaseEntity<TData>, IPersonEntity
        where TData : PersonInfoData, new()
    {
        protected Person() : this(null){}
        protected Person(TData d) : base(d){}

        public string LastName => Data?.LastName ?? "Unspecified";
        public string FirstName => Data?.FirstName ?? "Unspecified";
        public string FullName => $"{LastName}, {FirstName}";
        public DateTime BirthDay => Data?.Birthday ?? default;
    }
}
