using MediatR;
using TaxiApp.Application.Users.Dtos;

namespace TaxiApp.Application.Users.Queries.GetUserList
{
    public sealed record GetUserListQuery : IRequest<List<UserListItemDto>>;
}
