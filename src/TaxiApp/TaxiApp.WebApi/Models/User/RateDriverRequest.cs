using TaxiApp.Application.Users.Commands.RateDriver;

namespace TaxiApp.WebApi.Models.User
{
    public sealed class RateDriverRequest
    {
        public double Rating { get; set; }

        public RateDriverCommand MapToRateDriverCommand(Guid driverId)
            => new RateDriverCommand(driverId, Rating);
    }
}
