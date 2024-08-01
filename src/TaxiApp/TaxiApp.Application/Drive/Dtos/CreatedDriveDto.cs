namespace TaxiApp.Application.Drive.Dtos
{
    public sealed class CreatedDriveDto
    {
        private CreatedDriveDto(int estimatedDriverArrivingTime, double etimatedPrice)
        {
            EstimatedDriverArrivingTime = estimatedDriverArrivingTime;
            EstimatedPrice = etimatedPrice;
        }

        public int EstimatedDriverArrivingTime { get; set; }
        public double EstimatedPrice { get; set; }

        public static CreatedDriveDto Create(int estimatedDriverArrivingTime, double etimatedPrice)
            => new CreatedDriveDto(estimatedDriverArrivingTime, etimatedPrice);
    }
}
