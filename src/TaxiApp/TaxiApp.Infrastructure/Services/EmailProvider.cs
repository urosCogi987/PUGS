using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net.Mail;
using TaxiApp.Application.Abstractions;

namespace TaxiApp.Infrastructure.Services
{
    public sealed class EmailProvider(IConfiguration configuration) : IEmailProvider
    {
        public async Task SendConfirmationEmaiAsync(string email, string token)
        {
            string content = $"OOOOOOO/{token}";

            var client = new SendGridClient(configuration["Sendgrid:ApiKey"]);
            var from_email = new EmailAddress(configuration["Sendgrid:Verifiedsender"]);
            var subject = "VerifyEmail";
            var to_email = new EmailAddress(email);
            var plainTextContent = $"Verify email: {content}";
            var htmlContent = $"<strong>Verify email: <a href=\"{content}\">verify</strong>";
            var msg = MailHelper.CreateSingleEmail(from_email, to_email, subject, plainTextContent, htmlContent);

            var response = await client.SendEmailAsync(msg).ConfigureAwait(false);
        }

        public async Task SendUserVerifiedEmailToAdminAsync(string userEmail, string username)
        {
            string content = $"User with email {userEmail} and username {username} has been registered";

            var client = new SendGridClient(configuration["Sendgrid:ApiKey"]);
            var from_email = new EmailAddress(configuration["Sendgrid:Verifiedsender"]);
            var subject = "VerifyEmail";
            var to_email = new EmailAddress(configuration["Admin:Email"]);
            var plainTextContent = content;
            var htmlContent = $"<strong>{content}</strong>";
            var msg = MailHelper.CreateSingleEmail(from_email, to_email, subject, plainTextContent, htmlContent);

            var response = await client.SendEmailAsync(msg).ConfigureAwait(false);
        }
    }
}
