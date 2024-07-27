using MediatR;
using TaxiApp.Application.Users.Dtos;

namespace TaxiApp.Application.Users.Queries.GetProfile
{
    public sealed record GetCurrentUserQuery : IRequest<UserProfileDto>;  
}
