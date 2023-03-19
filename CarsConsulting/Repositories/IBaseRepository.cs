using CarsConsulting.DAL.Models;
using System.Linq.Expressions;

namespace CarsConsulting.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        public Task<List<T>> GetAllAsync();
        public Task<T?> GetByIdAsync(Guid id);
        public Task<List<T>> GetAsync(Expression<Func<T, bool>> predicate);
        public Task AddAsync(T entity);
        public Task UpdateAsync(T entity);
        public Task DeleteAsync(Guid id);
    }
}
