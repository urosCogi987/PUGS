using MediatR;
using TaxiApp.Application.Users.Dtos;

namespace TaxiApp.Application.Users.Queries.GetUser
{
    public sealed record GetUserDetailsQuery(Guid Id) : IRequest<UserDetailsDto>;    
}
