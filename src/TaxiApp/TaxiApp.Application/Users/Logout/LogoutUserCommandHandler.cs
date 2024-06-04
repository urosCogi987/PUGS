using MediatR;
using TaxiApp.Domain.Repositories;

namespace TaxiApp.Application.Users.Logout
{
    internal sealed class LogoutUserCommandHandler(IRefreshTokenRepository refreshTokenRepository) : IRequestHandler<LogoutUserCommand>
    {
        public async Task Handle(LogoutUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
