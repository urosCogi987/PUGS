using MediatR;
using TaxiApp.Application.Constants;
using TaxiApp.Application.Users.Dtos;
using TaxiApp.Domain.Repositories;
using TaxiApp.Kernel.Exeptions;

namespace TaxiApp.Application.Users.Queries.GetUser
{
    internal sealed class GetUserDetailsQueryHandler(
        IUserRepository userRepository) : IRequestHandler<GetUserDetailsQuery, UserDetailsDto>
    {
        public async Task<UserDetailsDto> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetUserWithRoles(request.Id);
            if (user is null)
            {
                throw new InvalidRequestException(DomainErrors.UserDoesNotExist);
            }            

            return UserDetailsDto.Create(user, user.Roles.ToList());
        }
    }
}
