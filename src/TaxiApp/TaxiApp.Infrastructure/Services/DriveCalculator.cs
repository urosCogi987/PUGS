using TaxiApp.Application.Abstractions;

namespace TaxiApp.Infrastructure.Services
{
    public sealed class DriveCalculator : IDriveCalculator
    {
        public (double estimatedPrice, int estimatedTime) CalculateDrive(double fromLatitude, double fromLongitude, double toLatitude, double toLongitude)
        {
            // TODO: calculate based on lat and lon
            Random random = new();
            return (random.Next(1, 1000), random.Next(1, 15));
        }
    }
}
