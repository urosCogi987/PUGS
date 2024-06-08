using FluentValidation;
using TaxiApp.Domain.Entities.Enum;
using TaxiApp.WebApi.Constants;
using TaxiApp.WebApi.Models;

namespace TaxiApp.WebApi.FluentValidation
{
    public class SetUserStatusRequestValidator : AbstractValidator<SetUserStatusRequest>
    {
        private static List<string> _userStatuses = Enum.GetNames(typeof(UserStatus)).ToList();
        
        public SetUserStatusRequestValidator()
        {
            RuleFor(x => x.UserStatus)
                .NotEmpty()
                .WithMessage(FluentValidationMessages.UserStatusIsRequired)
                .Must(_userStatuses.Contains)
                .WithMessage(FluentValidationMessages.ValidUserStatuses + string.Join(", ", _userStatuses));
        }
    }
}
