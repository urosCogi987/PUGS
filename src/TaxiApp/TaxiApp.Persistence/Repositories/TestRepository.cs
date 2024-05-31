using TaxiApp.Domain.Entities;
using TaxiApp.Domain.Repositories;

namespace TaxiApp.Persistence.Repositories
{
    public class TestRepository : ITestRepository
    {
        private static List<TestEntity> _entities = new() { new TestEntity() { Name = "name"}, new TestEntity() { Name = "name2" } };
        public async Task<List<TestEntity>> GetAll()
        {
            return _entities;
        }
    }
}
