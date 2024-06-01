using FluentValidation;
using TaxiApp.WebApi.Constants;
using TaxiApp.WebApi.Models;

namespace TaxiApp.WebApi.FluentValidation
{
    public sealed class RegisterUserRequestValidator : AbstractValidator<RegisterUserRequest>
    {
        public RegisterUserRequestValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage(FluentValidationMessages.UsernameIsRequired);

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage(FluentValidationMessages.EmailFormatIncorrect);

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(FluentValidationMessages.NameIsRequired);

            RuleFor(x => x.Surname)
                .NotEmpty()
                .WithMessage(FluentValidationMessages.SurnameIsRequired);

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage(FluentValidationMessages.PasswordIsRequired);

            RuleFor(x => x.RepeatPassword)
                .NotEmpty()
                .WithMessage(FluentValidationMessages.RepeatPasswordIsRequired)
                .Equal(x => x.Password)
                .WithMessage(FluentValidationMessages.PasswordsDoNotMatch);
            
            RuleFor(x => x.DateOfBirth)
                .NotEmpty()
                .WithMessage(FluentValidationMessages.DateOfBirthIsRequired)
                .LessThan(x => DateTime.Now)
                .WithMessage(FluentValidationMessages.DateOfBirthInvalid);

            RuleFor(x => x.Address)
                .NotEmpty()
                .WithMessage(FluentValidationMessages.AddressIsRequired);
        }
    }
}
