using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Layer.Abstraction
{
    public interface IGenericRepository<T> where T : class
    {
        #region Commands
        public Task AddAsync(T entity);
        public void DeleteAsync(T entity);
        public void DeleteAsync(int id);
        public Task UpdateAsync(T entity);
        #endregion

        #region Queries
        public Task<IEnumerable<T>> GetAllAsync();
        public ValueTask<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);
        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate);
        #endregion
    }
}
