using TaxiApp.Domain.DomainEvents;
using TaxiApp.Domain.Entities.Enum;

namespace TaxiApp.Domain.Entities
{
    public sealed class User : BaseEntity
    {
        private User(Guid id, string username, string email, string password, string name, string surname, 
                     string address, DateTime dateOfBirth, UserStatus userStatus, bool isEmailVerified = false) : base(id)
        {            
            Username = username;
            Email = email;                      
            Password = password;
            Name = name;
            Surname = surname;
            Address = address;
            DateOfBirth = dateOfBirth;       
            IsEmailVerified = isEmailVerified;
            UserStatus = userStatus;
        }        

        public string Username { get; private set; }
        public string Email { get; private set; }        
        public string Password { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Address { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public UserStatus UserStatus { get; private set; }
        public bool IsEmailVerified { get; private set; }        

        public ICollection<RefreshToken>? RefreshTokens { get; private set; }               
        public ICollection<VerificationToken>? VerificationTokens { get; private set; }


        public void VerifyEmail()
        {
            IsEmailVerified = true;
            RaiseDomainEvent(new UserVerifiedEmailDomainEvent(Guid.NewGuid(), Id));
        }

        public void SetStatus(UserStatus userStatus)
            => UserStatus = userStatus;

        public void UpdateProfile(string username, string name, string surname, string address, DateTime dateOfBirth)
        {
            Username = username;
            Name = name;
            Surname = surname;            
            Address = address;
            DateOfBirth = dateOfBirth;
        }

        public void ChangePassword(string newPassword)
            => Password = newPassword;
       
        public static User Create(Guid id, string username, string email, string password, string name, 
                                          string surname, string address, DateTime dateOfBirth, UserStatus userStatus)
            => new User(id, username, email, password, name, surname, address, dateOfBirth, userStatus);
                        
        public static User CreateAdmin(Guid id, string username, string email, string password, string name,
                                          string surname, string address, DateTime dateOfBirth, UserStatus userStatus)
            => new User(id, username, email, password, name, surname, address, dateOfBirth, userStatus, true);
    }
}
