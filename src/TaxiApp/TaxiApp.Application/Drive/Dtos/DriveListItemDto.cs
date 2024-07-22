namespace TaxiApp.Application.Drive.Dtos
{
    public sealed class DriveListItemDto
    {
        private DriveListItemDto(string fromAddress, string toAddress, DateTime createdOn)
        {
            FromAddress = fromAddress;
            ToAddress = toAddress;
            CreatedOn = createdOn;
        }

        public string FromAddress { get; set; }
        public string ToAddress { get; set; }
        public DateTime CreatedOn { get; set; }

        public static DriveListItemDto Create(string fromAddress, string toAddress, DateTime createdOn)
            => new DriveListItemDto(fromAddress, toAddress, createdOn);
    }
}
