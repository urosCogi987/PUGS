using FluentValidation;
using TaxiApp.WebApi.Models.Drive;

namespace TaxiApp.WebApi.FluentValidation
{
    public class CreateDriveRequestValidator : AbstractValidator<CreateDriveRequest>
    {
        public CreateDriveRequestValidator()
        {
            
        }
    }
}
