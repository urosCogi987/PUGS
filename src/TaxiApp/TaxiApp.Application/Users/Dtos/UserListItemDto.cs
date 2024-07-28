using System.Collections.Generic;
using TaxiApp.Domain.Entities;

namespace TaxiApp.Application.Users.Dtos
{
    public sealed class UserListItemDto : UserProfileDto
    {
        private UserListItemDto(User user, List<Role> roles) : base(user, roles)
        {
            Id = user.Id;
        }

        public Guid Id { get; set; }

        public static new UserListItemDto Create(User user, List<Role> roles)
            => new UserListItemDto(user, roles);
    }
}
