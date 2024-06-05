using MediatR;
using TaxiApp.Application.Abstractions;
using TaxiApp.Domain.Repositories;

namespace TaxiApp.Application.Users.Logout
{
    internal sealed class LogoutUserCommandHandler(
        IRefreshTokenRepository refreshTokenRepository, 
        IUserContext userContext) : IRequestHandler<LogoutUserCommand>
    {
        public async Task Handle(LogoutUserCommand request, CancellationToken cancellationToken)
        {
            if (!userContext.IsAuthenticated)
                throw new ApplicationException("User not authenticated.");
               
            var token = await refreshTokenRepository.FindAll(x => x.UserId == userContext.UserId && !x.IsUsed);
            if (token is null)
                throw new ApplicationException("Token does not exist.");

            await refreshTokenRepository.DeleteItemsRangeAsync(token);
        }
    }
}
