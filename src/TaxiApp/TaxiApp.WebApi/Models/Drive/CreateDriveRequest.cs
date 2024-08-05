using TaxiApp.Application.Drive.Commands.Create;

namespace TaxiApp.WebApi.Models.Drive
{
    public sealed class CreateDriveRequest
    {
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
        public double Distance { get; set; }
        public int EstimatedDuration { get; set; }

        public CreateDriveCommand MapToCreateDriveCommand()
            => new CreateDriveCommand(FromAddress, ToAddress, Distance, EstimatedDuration);
    }
}
