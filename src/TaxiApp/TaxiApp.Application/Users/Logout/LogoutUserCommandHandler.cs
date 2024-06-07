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

            RefreshToken? token = await refreshTokenRepository.Find(x => x.UserId == userContext.UserId && !x.IsUsed && x.Value == request.RefreshToken);
            if (token is not null)
            {
                await refreshTokenRepository.DeleteItemAsync(token);
            }            
            else
            {
                List<RefreshToken> refreshTokens = (await refreshTokenRepository.FindAll(x => x.UserId == userContext.UserId)).ToList();
                if (refreshTokens.Any()) 
                    await refreshTokenRepository.DeleteItemsRangeAsync(refreshTokens);
            }                   
        }
    }
}
