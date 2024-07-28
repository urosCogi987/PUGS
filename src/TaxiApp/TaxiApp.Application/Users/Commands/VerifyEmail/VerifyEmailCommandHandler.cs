using MediatR;
using TaxiApp.Application.Constants;
using TaxiApp.Domain.Entities;
using TaxiApp.Domain.Entities.Enum;
using TaxiApp.Domain.Repositories;
using TaxiApp.Kernel.Constants;
using TaxiApp.Kernel.Exeptions;

namespace TaxiApp.Application.Users.Commands.VerifyEmail
{
    internal sealed class VerifyEmailCommandHandler(
        IUserRepository userRepository,
        IRoleRepository roleRepository) : IRequestHandler<VerifyEmailCommand>
    {
        public async Task Handle(VerifyEmailCommand request, CancellationToken cancellationToken)
        {
            User? user = await userRepository.GetUserByVerificationToken(request.VerificationToken);
            if (user is null)
            {
                throw new InvalidRequestException(DomainErrors.InvalidVerificationToken);
            }

            user.VerifyEmail();            

            var roles = await roleRepository.GetRolesForUser(user.Id);
            if (roles.Any(x => x.Name == RoleNames.User))
            {
                user.SetStatus(UserStatus.Active);
            }            

            await userRepository.UpdateItemAsync(user);
        }
    }
}
