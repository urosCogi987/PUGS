using MediatR;
using TaxiApp.Application.Abstractions;
using TaxiApp.Domain.Entities;
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

            List<RefreshToken> tokens = (await refreshTokenRepository.FindAll(x => x.UserId == userContext.UserId && !x.IsUsed)).ToList();
            if (!tokens.Any())
                throw new ApplicationException("Tokens do not exist.");

            await refreshTokenRepository.DeleteItemsRangeAsync(tokens);
        }
    }
}
