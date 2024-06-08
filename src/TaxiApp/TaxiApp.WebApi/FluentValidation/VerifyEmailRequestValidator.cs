using FluentValidation;
using TaxiApp.WebApi.Constants;
using TaxiApp.WebApi.Models;

namespace TaxiApp.WebApi.FluentValidation
{
    public class VerifyEmailRequestValidator : AbstractValidator<VerifyEmailRequest>
    {
        public VerifyEmailRequestValidator()
        {
            RuleFor(x => x.VerificationToken)
                .NotEmpty()
                .WithMessage(FluentValidationMessages.VerificationTokenIsRequired);
        }
    }
}
