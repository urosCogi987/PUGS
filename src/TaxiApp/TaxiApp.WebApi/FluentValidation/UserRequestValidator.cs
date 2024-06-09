using FluentValidation;
using TaxiApp.WebApi.Constants;
using TaxiApp.WebApi.Models.User;

namespace TaxiApp.WebApi.FluentValidation
{
    public class UserRequestValidator : AbstractValidator<UserRequest>
    {
        public UserRequestValidator()
        {
            RuleFor(x => x.Username)
               .NotEmpty()
               .WithMessage(FluentValidationMessages.UsernameIsRequired);

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(FluentValidationMessages.NameIsRequired);

            RuleFor(x => x.Surname)
                .NotEmpty()
                .WithMessage(FluentValidationMessages.SurnameIsRequired);

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
