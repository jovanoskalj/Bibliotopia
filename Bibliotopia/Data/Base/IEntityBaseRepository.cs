using Bibliotopia.Models;
using System;
using System.Linq.Expressions;

namespace Bibliotopia.Data.Base
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        Task<IEnumerable<T>> GetAll();
       
        Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] includeProperties); 
        Task<T> GetById(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(int id, T entity);
        Task DeleteAsync(int id);
    }
}

