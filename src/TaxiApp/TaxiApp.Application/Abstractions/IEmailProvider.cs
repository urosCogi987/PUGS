namespace TaxiApp.Application.Abstractions
{
    public interface IEmailProvider
    {
        Task SendConfirmationEmaiAsync(string email, string token);
        Task SendUserVerifiedEmailToAdminAsync(string userEmail, string username);
    }
}
