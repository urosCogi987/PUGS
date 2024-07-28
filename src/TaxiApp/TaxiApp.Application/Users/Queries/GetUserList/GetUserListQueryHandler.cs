using MediatR;
using TaxiApp.Application.Users.Dtos;
using TaxiApp.Domain.Entities;
using TaxiApp.Domain.Repositories;

namespace TaxiApp.Application.Users.Queries.GetUserList
{
    internal sealed class GetUserListQueryHandler(
        IUserRepository userRepository): IRequestHandler<GetUserListQuery, List<UserListItemDto>>
    {
        public async Task<List<UserListItemDto>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var users = (await userRepository.GetUsersWithRoles()).ToList();
            return users.ConvertAll(x => UserListItemDto.Create(x, x.Roles.ToList()));
        }
    }
}
