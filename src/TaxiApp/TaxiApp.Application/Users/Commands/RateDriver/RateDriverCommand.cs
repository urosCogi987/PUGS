using MediatR;

namespace TaxiApp.Application.Users.Commands.RateDriver
{
    public sealed record RateDriverCommand(Guid DriverId, double Rating) : IRequest;   
}
