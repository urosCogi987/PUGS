using TaxiApp.Application.Abstractions;

namespace TaxiApp.Infrastructure.Services
{
    public sealed class DriveCalculator : IDriveCalculator
    {
        private const double _pricePerMeterInEur = 0.05;
        private const int _timeDelimeter = 1000;
        // PRICE DOUBLE
        public (double estimatedPrice, int estimatedTime, int distance) CalculateDrive(double fromLatitude, double fromLongitude, double toLatitude, double toLongitude)
        {                        
            double rlat1 = Math.PI * fromLatitude / 180;
            double rlat2 = Math.PI * toLatitude / 180;
            double theta = fromLongitude - toLongitude;
            double rtheta = Math.PI * theta / 180;
            double distance =
                Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) *
                Math.Cos(rlat2) * Math.Cos(rtheta);
            distance = Math.Acos(distance);
            distance = distance * 180 / Math.PI;
            distance = distance * 60 * 1.1515;

            //return ((double)distance, (int)distance / 1000);
            Random random = new();
            int dist = random.Next(1, 10000);
            return (dist * _pricePerMeterInEur, dist / _timeDelimeter, dist);
        }

        public (int estimatedDriverArrivalTime, double estimatedPrice) CalculateDriveV2(double distance)
        {
            Random random = new();
            int driverArrivalTime = random.Next(1, 10);
            return (driverArrivalTime, distance / _pricePerMeterInEur);
        }
    }
}
