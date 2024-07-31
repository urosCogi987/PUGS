using TaxiApp.Domain.Entities;

namespace TaxiApp.Application.Users.Dtos
{
    public sealed class UserDetailsDto : UserProfileDto
    {
        public UserDetailsDto(User user, List<Role> roles) : base(user, roles)
        {
            Id = user.Id;
        }

        public Guid Id { get; set; }

        public static new UserDetailsDto Create(User user, List<Role> roles)
            => new UserDetailsDto(user, roles);
    }
}
