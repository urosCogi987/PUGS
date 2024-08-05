using MediatR;

namespace TaxiApp.Application.Users.Commands.RateDriver
{
    internal sealed class RateDriverCommandHandler : IRequestHandler<RateDriverCommand>
    {
        public async Task Handle(RateDriverCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
