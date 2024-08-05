using MediatR;

namespace TaxiApp.Application.Drive.Commands.RateDriver
{
    public sealed record RateDriverCommand(Guid Id, Guid DriverId, int Rating) : IRequest;
}
