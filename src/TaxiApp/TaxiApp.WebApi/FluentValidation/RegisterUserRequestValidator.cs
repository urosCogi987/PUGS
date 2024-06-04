using FluentValidation;
using TaxiApp.WebApi.Constants;
using TaxiApp.WebApi.Models;

namespace TaxiApp.WebApi.FluentValidation
{
    public sealed class RegisterUserRequestValidator : AbstractValidator<RegisterUserRequest>
    {
        private const int _minPasswordLength = 8;
        private const int _maxPasswordLength = 50;
        private readonly string _passwordConstaints
            = $"Must be between {_minPasswordLength} and {_maxPasswordLength} characters.";
        private static List<string> _roleNames = new() { Kernel.Constants.RoleNames.User, Kernel.Constants.RoleNames.User };

        public RegisterUserRequestValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage(FluentValidationMessages.UsernameIsRequired);

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage(FluentValidationMessages.EmailIsRequired)
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
                .WithMessage(FluentValidationMessages.PasswordIsRequired)                
                .Length(_minPasswordLength, _maxPasswordLength)
                .WithMessage(FluentValidationMessages.PasswordLengthInvalid + _passwordConstaints);

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

            RuleFor(x => x.RoleName)
                .NotEmpty()
                .WithMessage(FluentValidationMessages.RoleNameIsRequired)
                .Must(x => _roleNames.Contains(x))
                .WithMessage(FluentValidationMessages.ValidRoleNames + string.Join(", ", _roleNames));
        }
    }
}
