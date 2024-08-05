using TaxiApp.Domain.Entities.Enum;

namespace TaxiApp.Application.Drive.Dtos
{
    public sealed class DriveListItemDto
    {
        private DriveListItemDto(Guid id, string fromAddress, string toAddress, DateTime createdOn, DriveStatus status)
        {
            Id = id;
            FromAddress = fromAddress;
            ToAddress = toAddress;
            CreatedOn = createdOn;
            Status = status;
        }

        public Guid Id { get; set; }
        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
        public DateTime CreatedOn { get; set; }
        public DriveStatus Status { get; set; }

        public static DriveListItemDto Create(Guid id, string fromAddress, string toAddress, DateTime createdOn, DriveStatus status)
            => new DriveListItemDto(id, fromAddress, toAddress, createdOn, status);
    }
}
