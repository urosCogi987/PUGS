using MediatR;
using TaxiApp.Application.Abstractions;
using TaxiApp.Application.Users.Dtos;
using TaxiApp.Domain.Repositories;

namespace TaxiApp.Application.Users.Queries.GetUserList
{
    internal sealed class GetUserListQueryHandler(
        IUserRepository userRepository,
        IUserContext userContext): IRequestHandler<GetUserListQuery, List<UserListItemDto>>
    {
        public async Task<List<UserListItemDto>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var users = await userRepository.GetUsersWithRoles();
            return users.Where(x => x.Id != userContext.UserId)
                .ToList().
                ConvertAll(x => UserListItemDto.Create(x, x.Roles.ToList()));
        }
    }
}
