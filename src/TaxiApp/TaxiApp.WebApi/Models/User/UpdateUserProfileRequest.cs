using TaxiApp.Application.Users.Commands.UpdateProfile;

namespace TaxiApp.WebApi.Models.User
{
    public class UpdateUserProfileRequest : UserRequest
    {
       public UpdateUserProfileCommand MapToUpdateUesrProfileCommand()
            => new UpdateUserProfileCommand(Username, Name, Surname, Address, DateOfBirth);
    }
}
