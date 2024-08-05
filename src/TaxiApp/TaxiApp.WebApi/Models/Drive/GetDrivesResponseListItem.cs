using TaxiApp.Application.Drive.Dtos;

namespace TaxiApp.WebApi.Models.Drive
{
    public sealed class GetDrivesResponseListItem
    {
        public GetDrivesResponseListItem(DriveListItemDto drivesDto)
        {
            Id = drivesDto.Id;
            FromAddress = drivesDto.FromAddress;
            ToAddress = drivesDto.ToAddress;
            CreatedOn = drivesDto.CreatedOn;
            Status = drivesDto.Status.ToString();
        }

        public Guid Id { get; set; }
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
        public DateTime CreatedOn { get; set; }  
        public string Status { get; set; }
    }
}
