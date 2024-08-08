using FluentValidation;
using TaxiApp.WebApi.Constants;
using TaxiApp.WebApi.Models.Drive;

namespace TaxiApp.WebApi.FluentValidation
{
    public class RateDriverRequestValidator : AbstractValidator<RateDriverRequest>
    {
        public RateDriverRequestValidator()
        {
            RuleFor(x => x.Rating)
                .NotEmpty()
                .WithMessage(FluentValidationMessages.DriverRatingIsRequired)
                .GreaterThanOrEqualTo(1)
                .WithMessage(FluentValidationMessages.DriverRatingGreaterOrEqual)
                .LessThanOrEqualTo(5)
                .WithMessage(FluentValidationMessages.DriverRatingLessThanOrEqual);
        }
    }
}
