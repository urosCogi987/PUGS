using FluentValidation;
using TaxiApp.WebApi.Constants;
using TaxiApp.WebApi.Models.User;

namespace TaxiApp.WebApi.FluentValidation
{
    public sealed class ChangePasswordRequestValidator : AbstractValidator<ChangePasswordRequest>
    {
        public ChangePasswordRequestValidator()
        {
            RuleFor(x => x.OldPassword)
                .NotEmpty()
                .WithMessage(FluentValidationMessages.OldPasswordIsRequired);

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage(FluentValidationMessages.PasswordIsRequired)
                .Length(StringLengths.MinPasswordLength, StringLengths.MaxPasswordLength)
                .WithMessage(FluentValidationMessages.PasswordLengthInvalid + FluentValidationMessages.PasswordConstaints);

            RuleFor(x => x.RepeatPassword)
                .NotEmpty()
                .WithMessage(FluentValidationMessages.RepeatPasswordIsRequired)
                .Equal(x => x.Password)
                .WithMessage(FluentValidationMessages.PasswordsDoNotMatch);
        }
    }
}
