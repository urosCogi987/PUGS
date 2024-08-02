using TaxiApp.Application.Drive.Dtos;

namespace TaxiApp.WebApi.Models.Drive
{
    public class CreatedDriveResponse
    {
        public CreatedDriveResponse(CreatedDriveDto createdDrive)
        {
            Id = createdDrive.Id;
            EstimatedDriverArrivingTime = createdDrive.EstimatedDriverArrivingTime;
            EstimatedPrice = createdDrive.EstimatedPrice;
        }

        public Guid Id { get; set; }
        public int EstimatedDriverArrivingTime { get; set; }
        public double EstimatedPrice { get; set; }        
    }
}
