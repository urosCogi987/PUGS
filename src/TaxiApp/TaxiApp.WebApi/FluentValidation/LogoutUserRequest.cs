using FluentValidation;
using TaxiApp.WebApi.Constants;
using TaxiApp.WebApi.Models.User;

namespace TaxiApp.WebApi.FluentValidation
{
    public class LogoutUserRequest : AbstractValidator<LogoutUserRequeset>
    {
        public LogoutUserRequest()
        {
            RuleFor(x => x.RefreshToken)
                .NotEmpty()
                .WithMessage(FluentValidationMessages.RefreshTokenIsRequired);
        }
    }
}
