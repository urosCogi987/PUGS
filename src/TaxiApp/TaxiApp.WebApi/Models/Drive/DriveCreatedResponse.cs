using TaxiApp.Application.Dtos;

namespace TaxiApp.WebApi.Models.Drive
{
    public sealed class DriveCreatedResponse
    {
        public DriveCreatedResponse(CreatedDriveDto createdDriveDto)
        {
            Price = createdDriveDto.Price;
            EstimatedTime = createdDriveDto.EstimatedTime;
            Distance = createdDriveDto.Distance;
        }

        public double Price { get; set; }
        public int EstimatedTime { get; set; }
        public int Distance { get; set; }
    }
}
