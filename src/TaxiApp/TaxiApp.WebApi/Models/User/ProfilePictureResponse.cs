using TaxiApp.Application.Abstractions;

namespace TaxiApp.WebApi.Models.User
{
    public sealed class ProfilePictureResponse
    {        
        public string Base64 { get; set; }
        public string ContentType { get; set; }

        public ProfilePictureResponse(FileResponse file)
        {
            Base64 = file.Base64;
            ContentType = file.ContentType;
        }
    }
}
