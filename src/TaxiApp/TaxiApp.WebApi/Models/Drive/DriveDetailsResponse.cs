using DriveEntity = TaxiApp.Domain.Entities.Drive;

namespace TaxiApp.WebApi.Models.Drive
{
    public sealed class DriveDetailsResponse
    {
        private DriveDetailsResponse(DriveEntity drive)
        {
            FromAddress = drive.FromAddress;
            ToAddress = drive.ToAddress;
            DriveTime = drive.DriveTime;
            DriverArrivingTime = drive.DriverArrivingTime;
            Distance = drive.Distance;
            Price = drive.Price;
            CreatedOn = drive.CreatedOn;
            Status = drive.Status.ToString();
        }

        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
        public int DriveTime { get; set; }
        public int DriverArrivingTime { get; set; }
        public int Distance { get; set; }
        public double Price { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Status { get; set; }


        public static DriveDetailsResponse Create(DriveEntity drive)
            => new DriveDetailsResponse(drive);
    }
}
