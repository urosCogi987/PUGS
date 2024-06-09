using FluentValidation;
using TaxiApp.WebApi.Constants;
using TaxiApp.WebApi.Models.User;

namespace TaxiApp.WebApi.FluentValidation
{
    public sealed class RegisterUserRequestValidator : AbstractValidator<RegisterUserRequest>
    {        
        private static List<string> _roleNames = new() { Kernel.Constants.RoleNames.User, Kernel.Constants.RoleNames.Driver };

        public RegisterUserRequestValidator()
        {
            Include(new UserRequestValidator());           

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage(FluentValidationMessages.EmailIsRequired)
                .EmailAddress()
                .WithMessage(FluentValidationMessages.EmailFormatIncorrect);                        

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

            RuleFor(x => x.RoleName)
                .NotEmpty()
                .WithMessage(FluentValidationMessages.RoleNameIsRequired)
                .Must(x => _roleNames.Contains(x))
                .WithMessage(FluentValidationMessages.ValidRoleNames + string.Join(", ", _roleNames));
        }
    }
}
