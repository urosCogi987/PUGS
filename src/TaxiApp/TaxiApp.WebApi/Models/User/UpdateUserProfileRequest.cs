using TaxiApp.Application.Users.Commands.UpdateProfile;

namespace TaxiApp.WebApi.Models.User
{
    public class UpdateUserProfileRequest : UserRequest
    {

       public UpdateUserProfileCommand MapToUpdateUesrProfileCommand(Guid id)
            => new UpdateUserProfileCommand(id, Username, Name, Surname, Address, DateOfBirth);
    }
}
