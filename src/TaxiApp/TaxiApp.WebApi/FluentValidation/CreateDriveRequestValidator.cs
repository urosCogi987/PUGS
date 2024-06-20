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

            RuleFor(x => x.ToLatitude)
                .NotEmpty()
                .WithMessage(FluentValidationMessages.ToLatitudeIsRequired)
                .LessThanOrEqualTo(80)
                .GreaterThanOrEqualTo(-80)
                .WithMessage(FluentValidationMessages.ValidLatitudes);

            RuleFor(x => x.ToLongitude)
                .NotEmpty()
                .WithMessage(FluentValidationMessages.ToLongitudeIsRequired)
                .LessThanOrEqualTo(180)
                .GreaterThanOrEqualTo(-180)
                .WithMessage(FluentValidationMessages.ValidLongitudes);

            RuleFor(x => x.FromLatitude)
                .NotEmpty()
                .WithMessage(FluentValidationMessages.FromLatitudeIsRequired)
                .LessThanOrEqualTo(80)
                .GreaterThanOrEqualTo(-80)
                .WithMessage(FluentValidationMessages.ValidLatitudes);

            RuleFor(x => x.FromLongitude)
               .NotEmpty()
               .WithMessage(FluentValidationMessages.FromLongitudeIsRequired)
               .LessThanOrEqualTo(180)
               .GreaterThanOrEqualTo(-180)
               .WithMessage(FluentValidationMessages.ValidLongitudes);
        }
    }
}
