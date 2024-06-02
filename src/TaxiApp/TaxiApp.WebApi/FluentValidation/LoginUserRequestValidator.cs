using FluentValidation;
using TaxiApp.WebApi.Constants;
using TaxiApp.WebApi.Models;

namespace TaxiApp.WebApi.FluentValidation
{
    public sealed class LoginUserRequestValidator : AbstractValidator<LoginUserRequest>
    {
        public LoginUserRequestValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage(FluentValidationMessages.EmailIsRequired);

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage(FluentValidationMessages.PasswordIsRequired);
        }
    }
}
