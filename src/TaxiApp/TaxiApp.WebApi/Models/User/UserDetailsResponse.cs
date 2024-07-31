using TaxiApp.Application.Users.Dtos;

namespace TaxiApp.WebApi.Models.User
{
    public sealed class UserDetailsResponse : UserProfileResponse
    {
        public UserDetailsResponse(UserDetailsDto userDetails) : base(userDetails)
        {
            Id = userDetails.Id;
        }

        public Guid Id { get; set; }
    }
}
