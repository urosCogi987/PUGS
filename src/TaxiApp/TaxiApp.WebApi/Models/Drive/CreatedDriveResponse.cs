using TaxiApp.Application.Drive.Dtos;

namespace TaxiApp.WebApi.Models.Drive
{
    public class CreatedDriveResponse
    {
        public CreatedDriveResponse(CreatedDriveDto createdDrive)
        {
            EstimatedDriverArrivingTime = createdDrive.EstimatedDriverArrivingTime;
            EstimatedPrice = createdDrive.EstimatedPrice;
        }

        public int EstimatedDriverArrivingTime { get; set; }
        public double EstimatedPrice { get; set; }        
    }
}
