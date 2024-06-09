using TaxiApp.Application.Users.Commands.SetStatus;
using TaxiApp.Domain.Entities.Enum;

namespace TaxiApp.WebApi.Models.User
{
    public class SetUserStatusRequest
    {
        public string UserStatus { get; set; }

        public SetUserStatusCommand MapToSetUserStatusCommand(Guid id)
            => new SetUserStatusCommand(id, (UserStatus)Enum.Parse(typeof(UserStatus), UserStatus));
    }
}
