using Microsoft.EntityFrameworkCore;
using TaxiApp.Kernel.Repositories;

namespace TaxiApp.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _dbContext;
        public Repository(ApplicationDbContext dbContext)        
            => _dbContext = dbContext;
        

        public async Task<T> AddItemAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteItemAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T?> GetItemByIdAsync(long id)
        {
            T? entity = await _dbContext.Set<T>().FindAsync(id);
            if (entity is not null)
                _dbContext.Entry(entity).State = EntityState.Detached;

            return entity;
        }

        public async Task<IEnumerable<T>> GetItemsAsync()
            => await _dbContext.Set<T>().AsNoTracking().ToListAsync();

        public async Task UpdateItemAsync(T entity)
        {
            _dbContext.Set<T>().Attach(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
