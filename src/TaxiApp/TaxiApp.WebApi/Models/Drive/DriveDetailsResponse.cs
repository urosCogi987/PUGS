using DriveEntity = TaxiApp.Domain.Entities.Drive;

namespace TaxiApp.WebApi.Models.Drive
{
    public sealed class DriveDetailsResponse
    {
        public DriveDetailsResponse(DriveEntity drive)
        {
            Id = drive.Id;
            UserUsername = drive.User.Username;
            DriverUsername = drive.Driver != null ? drive.Driver.Username : "";            
            FromAddress = drive.FromAddress;
            ToAddress = drive.ToAddress;
            DriveTime = drive.DriveTime;
            DriverArrivingTime = drive.DriverArrivingTime;
            Distance = drive.Distance;
            Price = drive.Price;
            CreatedOn = drive.CreatedOn;
            Status = drive.Status.ToString();
            DriverRating = drive.DriverRating;
        }

        public Guid Id { get; set; }
        public string DriverUsername { get; set; }
        public string UserUsername { get; set; }
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
        public int DriveTime { get; set; }
        public int DriverArrivingTime { get; set; }
        public double Distance { get; set; }
        public double Price { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Status { get; set; }
        public int? DriverRating { get; set; }
    }
}
