using MediatR;
using TaxiApp.Application.Users.Dtos;
using TaxiApp.Domain.Entities;
using TaxiApp.Domain.Repositories;

namespace TaxiApp.Application.Users.Queries.GetUserList
{
    internal sealed class GetUserListQueryHandler(
        IUserRepository userRepository,
        IRoleRepository roleRepository): IRequestHandler<GetUserListQuery, List<UserListItemDto>>
    {
        public async Task<List<UserListItemDto>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var users = await userRepository.GetItemsAsync();
            var roles = await roleRepository.GetRoleWithUsers(); //admin - 1, users - 2, 3 driver 4,5,6

            // Pod hitno promeni User -many-> Roles -many-> Permissions
            // Pod hitno promeni User -many-> Roles -many-> Permissions
            // Pod hitno promeni User -many-> Roles -many-> Permissions
            // Pod hitno promeni User -many-> Roles -many-> Permissions
            // Pod hitno promeni User -many-> Roles -many-> Permissions

            List<UserListItemDto> usersToReturn = new();
            foreach (var user in users)
            {
                foreach (var role in roles)
                {
                    if (role.Users.Any(x => x.Id == user.Id))
                    {
                        usersToReturn.Add(UserListItemDto.Create(user, new List<Role> { role }));
                    }
                }
            }
            // Pod hitno promeni User -many-> Roles -many-> Permissions
            // Pod hitno promeni User -many-> Roles -many-> Permissions
            return usersToReturn;
        }
    }
}
