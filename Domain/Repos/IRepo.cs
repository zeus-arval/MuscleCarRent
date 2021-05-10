using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MuscleCarRentProject.Domain.Repos
{
    public interface IRepo<T> : IPagedRepo, IFilteredRepo, IOrderedRepo
    {
        string ErrorMessage { get; }
        public T EntityInDb { get; }
        Task<List<T>> Get();
        Task<T> Get(string id);
        Task<bool> Delete(T obj);
        Task<bool> Add(T obj);
        Task<bool> Update(T obj);
        T GetById(string id);
    }
}
