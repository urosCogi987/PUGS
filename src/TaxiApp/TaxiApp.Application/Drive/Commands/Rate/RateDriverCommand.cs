using MediatR;

namespace TaxiApp.Application.Drive.Commands.RateDriver
{
    public sealed record RateDriverCommand(Guid Id, int Rating) : IRequest;
}
