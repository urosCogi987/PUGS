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
            Name = user.Name;
            Surname = user.Surname;
            Address = user.Address;
            DateOfBirth = user.DateOfBirth;
            RoleNames = user.Roles;
            Status = user.Status;
        }

        public Guid Id { get; set; }        
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
