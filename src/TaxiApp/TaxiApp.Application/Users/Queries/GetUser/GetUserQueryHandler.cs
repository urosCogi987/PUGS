using MediatR;
using TaxiApp.Application.Constants;
using TaxiApp.Application.Dtos;
using TaxiApp.Domain.Entities;
using TaxiApp.Domain.Repositories;
using TaxiApp.Kernel.Exeptions;

namespace TaxiApp.Application.Users.Queries.GetUser
{
    internal sealed class GetUserQueryHandler(
        IUserRepository userRepository,
        IRoleRepository roleRepository) : IRequestHandler<GetUserQuery, UserProfileDto>
    {
        public async Task<UserProfileDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            User? user = await userRepository.GetItemByIdAsync(request.id);
            if (user is null)
                throw new InvalidRequestException(DomainErrors.UserDoesNotExist);

            List<Role> roles = (await roleRepository.FindAll(x => x.Users.Contains(user))).ToList();

            return UserProfileDto.Create(user, roles);
        }
    }
}
