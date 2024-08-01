namespace TaxiApp.Application.Abstractions
{
    public interface IDriveCalculator
    {
        (double estimatedPrice, int estimatedTime, int distance) CalculateDrive(double fromLatitude, double fromLongitude, double toLatitude, double toLongitude);

        (int estimatedDriverArrivalTime, double estimatedPrice) CalculateDriveV2(double distance);
    }
}
