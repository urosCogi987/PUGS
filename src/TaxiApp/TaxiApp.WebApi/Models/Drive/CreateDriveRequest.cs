using TaxiApp.Application.Drive.Commands.Create;

namespace TaxiApp.WebApi.Models.Drive
{
    public sealed class CreateDriveRequest
    {
        public string FromAddress { get; set; }
        public double FromLatitude { get; set; }
        public double FromLongitude { get; set; }
        public string ToAddress { get; set; }
        public double ToLatitude { get; set; }
        public double ToLongitude { get; set; }

        public CreateDriveCommand MapToCreateDriveCommand()
            => new CreateDriveCommand(FromAddress, FromLatitude, FromLongitude, ToAddress, ToLatitude, ToLongitude);
    }
}
