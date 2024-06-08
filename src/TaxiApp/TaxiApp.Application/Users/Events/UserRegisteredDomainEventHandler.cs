using MediatR;
using TaxiApp.Application.Abstractions;
using TaxiApp.Domain.DomainEvents;
using TaxiApp.Domain.Entities;
using TaxiApp.Domain.Repositories;

namespace TaxiApp.Application.Users.Events
{
    internal sealed class UserRegisteredDomainEventHandler(
        IEmailProvider emailProvider,
        IUserRepository userRepository,
        IVerificationTokenRepository verificationTokenRepository) : INotificationHandler<UserRegisteredDomainEvent>
    {
        public async Task Handle(UserRegisteredDomainEvent notification, CancellationToken cancellationToken)
        {
            // Consider outbox pattern if there is time
            User? user = await userRepository.GetItemByIdAsync(notification.UserId);
            if (user is null)            
                return;

            VerificationToken? verificationToken = await verificationTokenRepository.Find(x => x.Id ==  notification.TokenId);
            if (verificationToken is null) 
                return;

            await emailProvider.SendConfirmationEmaiAsync(user.Email, verificationToken.Value);
        }
    }
}
