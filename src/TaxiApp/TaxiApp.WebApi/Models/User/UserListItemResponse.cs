using TaxiApp.Application.Users.Dtos;

namespace TaxiApp.WebApi.Models.User
{
    public class UserListItemResponse
    {
        public UserListItemResponse(UserListItemDto user)
        {
            Id = user.Id;
            Username = user.Username;
            Email = user.Email;            
            RoleNames = user.Roles;
            Status = user.Status;
        }

        public Guid Id { get; set; }        
        public string Username { get; set; }
        public string Email { get; set; }        
        public List<string> RoleNames { get; set; } 
        public string Status { get; set; }        
    }
}
