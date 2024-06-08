using MediatR;

namespace TaxiApp.Application.Users.Commands.VerifyEmail
{
    public sealed record VerifyEmailCommand(string VerificationToken) : IRequest;
}
