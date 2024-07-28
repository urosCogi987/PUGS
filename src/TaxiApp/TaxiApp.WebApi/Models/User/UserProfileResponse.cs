using TaxiApp.Application.Users.Dtos;

namespace TaxiApp.WebApi.Models.User
{
    public class UserProfileResponse
    {
        public UserProfileResponse(UserProfileDto userProfile)
        {            
            Username = userProfile.Username;
            Email = userProfile.Email;
            Name = userProfile.Name;
            Surname = userProfile.Surname;
            Address = userProfile.Address;
            DateOfBirth = userProfile.DateOfBirth;
            RoleNames = userProfile.Roles;
            Status = userProfile.Status;
        }
        
        public string Username { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<string> RoleNames { get; set; }
        public string Status { get; set; }        
    }
}
