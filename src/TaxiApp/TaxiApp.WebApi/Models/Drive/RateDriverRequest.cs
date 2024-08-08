using TaxiApp.Application.Drive.Commands.RateDriver;

namespace TaxiApp.WebApi.Models.Drive
{
    public sealed class RateDriverRequest
    {
        public int Rating { get; set; }

        public RateDriverCommand MapToRateDriverCommand(Guid id)
            => new RateDriverCommand(id, Rating);
    }
}
