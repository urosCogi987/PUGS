using TaxiApp.Application.Users.Commands.VerifyEmail;

namespace TaxiApp.WebApi.Models
{
    public class VerifyEmailRequest
    {
        public string VerificationToken { get; set; }

        public VerifyEmailCommand MapToVerifyEmailCommand() 
            => new VerifyEmailCommand(VerificationToken);
    }
}
