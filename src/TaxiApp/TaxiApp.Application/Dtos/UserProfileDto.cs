using TaxiApp.Domain.Entities;

namespace TaxiApp.Application.Dtos
{
    public sealed class UserProfileDto
    {
        private UserProfileDto(User user, List<Role> roles)
        {
            Username = user.Username;
            Email = user.Email;
            Name = user.Name;
            Surname = user.Surname;
            Address = user.Address;
            DateOfBirth = user.DateOfBirth;            
            Status = user.UserStatus.ToString();
            roles.ForEach(x => Roles.Add(x.Name));
        }

        public string Username { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<string> Roles { get; set; } = new();
        public string Status { get; set; }

        public static UserProfileDto Create(User user, List<Role> roles)
         => new UserProfileDto(user, roles);
    }
}
