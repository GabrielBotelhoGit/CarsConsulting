using CarsConsulting.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CarsConsulting.Repositories
{
    public abstract class BaseRepository<T, Y> :IBaseRepository<T> where Y : DbContext where T : BaseEntity
    {
        private readonly Y _dbContext;
        protected readonly DbSet<T> _dbSet;

        protected BaseRepository(Y dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public Task<List<T>> GetAllAsync()
        {
            return _dbSet
                .AsNoTracking()
                .ToListAsync();
        }

        public Task<T?> GetByIdAsync(Guid id)
        {
            return _dbSet.
                FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return _dbSet
                .AsNoTracking()
                .Where(predicate)
                .ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            entity.UpdatedAt = DateTime.UtcNow;
            await _dbSet
                .AddAsync(entity);

            await _dbContext
                .SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            entity.UpdatedAt = DateTime.UtcNow;
            _dbSet.Update(entity);

            await _dbContext.
                SaveChangesAsync()
                .ConfigureAwait(false);
        }

        public async Task DeleteAsync(Guid id)
        {
            T? entity = await _dbSet
                .FindAsync(id)
                .ConfigureAwait(false);

            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
