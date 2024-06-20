using TaxiApp.Application.Drive.Commands.Accept;

namespace TaxiApp.WebApi.Models.Drive
{
    public sealed class AcceptDriveRequest
    {
        public int DriverArrivingTime { get; set; }

        public AcceptDriveCommand MapToAcceptDriveCommand(Guid id)
            => new AcceptDriveCommand(id, DriverArrivingTime);
    }
}
