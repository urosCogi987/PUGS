using TaxiApp.Application.Drive.Dtos;

namespace TaxiApp.WebApi.Models.Drive
{
    public sealed class GetDrivesResponseListItem
    {
        private GetDrivesResponseListItem(string fromAddress, string toAddress, DateTime createdOn)
        {
            FromAddress = fromAddress;
            ToAddress = toAddress;
            CreatedOn = createdOn;
        }

        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
        public DateTime CreatedOn { get; set; }

        public static GetDrivesResponseListItem Create(DriveListItemDto drivesDto)
            => new GetDrivesResponseListItem(drivesDto.FromAddress, drivesDto.ToAddress, drivesDto.CreatedOn);
    }
}
