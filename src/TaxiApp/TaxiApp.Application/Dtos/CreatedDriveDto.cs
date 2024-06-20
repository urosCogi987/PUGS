namespace TaxiApp.Application.Dtos
{
    public sealed class CreatedDriveDto
    {
        private CreatedDriveDto(double price, int estimatedTime, int distance)
        {
            Price = price;
            EstimatedTime = estimatedTime;
            Distance = distance;
        }

        public double Price { get; set; }
        public int EstimatedTime { get; set; }
        public int Distance { get; set; }

        public static CreatedDriveDto Create(double price, int estimatedTime, int distance)
            => new CreatedDriveDto(price, estimatedTime, distance);
    }
}
