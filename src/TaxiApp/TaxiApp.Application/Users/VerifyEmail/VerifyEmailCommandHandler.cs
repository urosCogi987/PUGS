using MediatR;
using TaxiApp.Application.Constants;
using TaxiApp.Domain.Entities;
using TaxiApp.Domain.Repositories;
using TaxiApp.Kernel.Exeptions;

namespace TaxiApp.Application.Users.VerifyEmail
{
    internal sealed class VerifyEmailCommandHandler(IUserRepository userRepository) : IRequestHandler<VerifyEmailCommand>
    {
        public async Task Handle(VerifyEmailCommand request, CancellationToken cancellationToken)
        {
            User? user = await userRepository.GetUserByVerificationToken(request.VerificationToken);
            if (user is null)
                throw new InvalidRequestException(DomainErrors.InvalidVerificationToken);

            user.VerifyEmail();

            await userRepository.UpdateItemAsync(user);
        }
    }
}
