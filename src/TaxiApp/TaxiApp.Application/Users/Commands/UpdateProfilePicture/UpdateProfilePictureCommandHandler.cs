using MediatR;
using TaxiApp.Application.Abstractions;

namespace TaxiApp.Application.Users.Commands.UpdateProfilePicture
{
    internal sealed class UpdateProfilePictureCommandHandler(
        IBlobService blobService,
        IUserContext userContext) : IRequestHandler<UpdateProfilePictureCommand>
    {
        public async Task Handle(UpdateProfilePictureCommand request, CancellationToken cancellationToken)
        {
            if (!userContext.IsAuthenticated)
                throw new ApplicationException("User not authenticated.");

            using Stream stream = request.File.OpenReadStream();
            var fileName = await blobService.UploadAsync(stream, request.File.ContentType, userContext.UserId); // To do: prosiri userTabelu sa img url
        }
    }
}
