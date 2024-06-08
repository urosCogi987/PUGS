using MediatR;

namespace TaxiApp.Application.Users.VerifyEmail
{
    public sealed record VerifyEmailCommand(string VerificationToken) : IRequest;    
}
