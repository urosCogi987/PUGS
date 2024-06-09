using TaxiApp.Domain.Entities.Enum;

namespace TaxiApp.Domain.Entities
{
    public sealed class Drive : BaseEntity
    {
        private Drive(Guid id, string fromAddress, double fromLatitude, double fromLongitude,
                      string toAddress, double toLatitude, double toLongitude, DriveStatus status) : base(id)
        {
            FromAddress = fromAddress;
            FromLatitude = fromLatitude;
            FromLongitude = fromLongitude;
            ToAddress = toAddress;
            ToLatitude = toLatitude;
            ToLongitude = toLongitude;
            Status = status;
        }

        public Guid? UserId { get; private set; }
        public Guid? DriverId { get; private set; }
        public string FromAddress { get; private set; }
        public double FromLatitude { get; private set; }
        public double FromLongitude { get; private set; }
        public string ToAddress { get; private set; }
        public double ToLatitude { get; private set; }
        public double ToLongitude { get; private set; }
        public int DriveTime { get; private set; }
        public int DriverArrivingTime { get; private set; }
        public DriveStatus Status { get; set; }

        public static Drive Create(Guid id, string fromAddress, double fromLatitude, double fromLongitude,
                                   string toAddress, double toLatitude, double toLongitude, DriveStatus status)
            => new Drive(id, fromAddress, fromLatitude, fromLongitude, toAddress, toLatitude, toLongitude, status);
    }
}
