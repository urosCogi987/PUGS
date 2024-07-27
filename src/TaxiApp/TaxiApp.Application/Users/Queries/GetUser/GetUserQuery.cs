using MediatR;
using TaxiApp.Application.Users.Dtos;

namespace TaxiApp.Application.Users.Queries.GetUser
{
    public sealed record GetUserQuery(Guid id) : IRequest<UserProfileDto>;    
}
