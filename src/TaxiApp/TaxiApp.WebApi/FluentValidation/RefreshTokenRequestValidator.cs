using FluentValidation;
using TaxiApp.WebApi.Constants;
using TaxiApp.WebApi.Models;

namespace TaxiApp.WebApi.FluentValidation
{
    public sealed class RefreshTokenRequestValidator : AbstractValidator<RefreshTokenRequest>
    {
        public RefreshTokenRequestValidator()
        {
            RuleFor(x => x.RefreshToken)
                .NotEmpty()
                .WithMessage(FluentValidationMessages.RefreshTokenIsRequired);
        }
    }
}
