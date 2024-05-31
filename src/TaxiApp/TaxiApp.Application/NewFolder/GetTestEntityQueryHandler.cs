using MediatR;
using TaxiApp.Domain.Entities;
using TaxiApp.Domain.Repositories;

namespace TaxiApp.Application.NewFolder
{
    internal sealed class GetTestEntityQueryHandler(ITestRepository testRepository) : IRequestHandler<GetTestEntityQuery, List<TestEntity>>
    {
        public async Task<List<TestEntity>> Handle(GetTestEntityQuery request, CancellationToken cancellationToken)
        {
            var entity = await testRepository.GetAll();
            return entity;
        }
    }
}
