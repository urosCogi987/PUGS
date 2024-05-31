using TaxiApp.Domain.Entities;

namespace TaxiApp.Domain.Repositories
{
    public interface ITestRepository
    {
        Task<List<TestEntity>> GetAll();
    }
}
