namespace TaxiApp.Application.Drive.Dtos
{
    public sealed class CreatedDriveDto
    {
        private CreatedDriveDto(Guid id, int estimatedDriverArrivingTime, double etimatedPrice)
        {
            Id = id;
            EstimatedDriverArrivingTime = estimatedDriverArrivingTime;
            EstimatedPrice = etimatedPrice;
        }

        public Guid Id { get; set; }
        public int EstimatedDriverArrivingTime { get; set; }
        public double EstimatedPrice { get; set; }

        public static CreatedDriveDto Create(Guid id, int estimatedDriverArrivingTime, double etimatedPrice)
            => new CreatedDriveDto(id, estimatedDriverArrivingTime, etimatedPrice);
    }
}
