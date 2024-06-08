using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TaxiApp.Domain.DomainEvents;
using TaxiApp.Domain.Entities;
using TaxiApp.Kernel.Repositories;

namespace TaxiApp.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationDbContext _dbContext;
        private readonly IPublisher _publisher;
        public Repository(ApplicationDbContext dbContext, IPublisher publisher)
        {
            _dbContext = dbContext;
            _publisher = publisher;
        }                    

        public async Task<T> AddItemAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            await PublishEvents(entity);
            return entity;
        }

        public async Task DeleteItemAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteItemsRangeAsync(IEnumerable<T> items)
        {
            _dbContext.Set<T>().RemoveRange(items);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T?> GetItemByIdAsync(Guid id)
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
            await PublishEvents(entity);
        }

        public async Task<IEnumerable<T>> FindAll(Expression<Func<T, bool>> predicate)
            => await _dbContext.Set<T>().AsNoTracking().Where(predicate).ToListAsync();

        public async Task<T?> Find(Expression<Func<T, bool>> predicate)
            => await _dbContext.Set<T>().AsNoTracking().Where(predicate).FirstOrDefaultAsync();      
        
        private async Task PublishEvents(T entity)
        {
            var events = entity.GetDomainEvents();
            foreach (IDomainEvent item in events)
            {
                await _publisher.Publish(item);
            }
            entity.ClearDomainEvents();
        }
    }
}
