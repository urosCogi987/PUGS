using TaxiApp.Domain.Entities;

namespace TaxiApp.Application.Users.Dtos
{
    public sealed class UserListItemDto
    {
        private UserListItemDto(User user, List<Role> roles)
        {
            Id = user.Id;
            Username = user.Username;
            Email = user.Email;
            roles.ForEach(x => Roles.Add(x.Name));
            Status = user.UserStatus.ToString();
        }

        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; } = new();
        public string Status { get; set; }

        public static UserListItemDto Create(User user, List<Role> roles)
            => new UserListItemDto(user, roles);
    }
}
