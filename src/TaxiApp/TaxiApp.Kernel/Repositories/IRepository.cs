using System.Linq.Expressions;

namespace TaxiApp.Kernel.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetItemByIdAsync(long id);
        Task<IEnumerable<T>> GetItemsAsync();
        Task<T> AddItemAsync(T entity);
        Task UpdateItemAsync(T entity);
        Task DeleteItemAsync(T entity);
        Task DeleteItemsRangeAsync(IEnumerable<T> items);
        Task<IEnumerable<T>> FindAll(Expression<Func<T, bool>> predicate);
        Task<T?> Find(Expression<Func<T, bool>> predicate);
    }
}
