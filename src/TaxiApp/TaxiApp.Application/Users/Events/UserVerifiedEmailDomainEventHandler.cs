using MediatR;
using TaxiApp.Application.Abstractions;
using TaxiApp.Domain.DomainEvents;
using TaxiApp.Domain.Entities;
using TaxiApp.Domain.Repositories;

namespace TaxiApp.Application.Users.Events
{
    internal sealed class UserVerifiedEmailDomainEventHandler(
        IUserRepository userRepository,
        IEmailProvider emailProvider) : INotificationHandler<UserVerifiedEmailDomainEvent>
    {
        public async Task Handle(UserVerifiedEmailDomainEvent notification, CancellationToken cancellationToken)
        {
            // Consider outbox pattern if there is time
            User? user = await userRepository.GetItemByIdAsync(notification.UserId);
            if (user is null)
                return;

            await emailProvider.SendUserVerifiedEmailToAdminAsync(user.Email, user.Username);
        }
    }
}
