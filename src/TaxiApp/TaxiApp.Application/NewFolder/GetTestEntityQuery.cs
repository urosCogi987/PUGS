using MediatR;
using TaxiApp.Domain.Entities;

namespace TaxiApp.Application.NewFolder
{
    public record GetTestEntityQuery : IRequest<List<TestEntity>>;    
}
