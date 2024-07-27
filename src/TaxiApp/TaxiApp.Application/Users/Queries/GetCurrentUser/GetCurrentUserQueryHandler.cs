using MediatR;
using TaxiApp.Application.Abstractions;
using TaxiApp.Application.Users.Dtos;
using TaxiApp.Domain.Entities;
using TaxiApp.Domain.Repositories;

namespace TaxiApp.Application.Users.Queries.GetProfile
{
    internal sealed class GetCurrentUserQueryHandler(
        IUserRepository userRepository,
        IUserContext userContext,
        IRoleRepository roleRepository) : IRequestHandler<GetCurrentUserQuery, UserProfileDto>
    {
        public async Task<UserProfileDto> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
        {
            if (!userContext.IsAuthenticated)
                throw new ApplicationException("User not authenticated.");

            var user = await userRepository.GetItemByIdAsync(userContext.UserId);
            if (user is null)
            {
                throw new ApplicationException("User does not exist.");
            }

            List<Role> roles = (await roleRepository.FindAll(x => x.Users.Contains(user))).ToList();

            return UserProfileDto.Create(user, roles);
        }
    }
}
