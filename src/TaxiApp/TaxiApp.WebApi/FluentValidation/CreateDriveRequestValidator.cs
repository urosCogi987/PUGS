using FluentValidation;
using TaxiApp.WebApi.Constants;
using TaxiApp.WebApi.Models.Drive;

namespace TaxiApp.WebApi.FluentValidation
{
    public class CreateDriveRequestValidator : AbstractValidator<CreateDriveRequest>
    {
        public CreateDriveRequestValidator()
        {
            RuleFor(x => x.FromAddress)
                .NotEmpty()
                .WithMessage(FluentValidationMessages.FromAddressIsRequired);

            RuleFor(x => x.ToAddress)
                .NotEmpty()
                .WithMessage(FluentValidationMessages.ToAddressIsRequired);

            RuleFor(x => x.Distance)
                .NotEmpty()
                .WithMessage(FluentValidationMessages.DistanceIsRequired)
                .GreaterThan(0)
                .WithMessage(FluentValidationMessages.DistanceHasToBeRealNumber);

            RuleFor(x => x.EstimatedDuration)
                .NotEmpty()
                .WithMessage(FluentValidationMessages.EstimatedDurationIsRequired)
                .GreaterThan(0)
                .WithMessage(FluentValidationMessages.EstimatedDurationHasToBeRealNumber);
        }
    }
}
