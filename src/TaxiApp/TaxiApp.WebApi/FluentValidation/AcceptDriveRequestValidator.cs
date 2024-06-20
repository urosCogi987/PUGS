using FluentValidation;
using TaxiApp.WebApi.Constants;
using TaxiApp.WebApi.Models.Drive;

namespace TaxiApp.WebApi.FluentValidation
{
    public sealed class AcceptDriveRequestValidator : AbstractValidator<AcceptDriveRequest>
    {
        public AcceptDriveRequestValidator()
        {
            RuleFor(x => x.DriverArrivingTime)
                .NotEmpty()
                .WithMessage(FluentValidationMessages.DriverArrivingTimeIsRequired)
                .GreaterThan(0)
                .WithMessage(FluentValidationMessages.DriverArrivingTimeGreaterThanZero);
        }
    }
}
