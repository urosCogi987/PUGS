namespace TaxiApp.Domain.Entities
{
    public sealed class User : BaseEntity
    {
        private User(Guid id, string username, string email, string password, string name,
                     string surname, string address, DateTime dateOfBirth) : base(id)
        {            
            Username = username;
            Email = email;                      
            Password = password;
            Name = name;
            Surname = surname;
            Address = address;
            DateOfBirth = dateOfBirth;            
        }        

        public string Username { get; private set; }
        public string Email { get; private set; }        
        public string Password { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Address { get; private set; }
        public DateTime DateOfBirth { get; private set; }        

        public ICollection<RefreshToken>? RefreshTokens { get; private set; }                

        public static User Create(Guid id, string username, string email, string password, string name, 
                                          string surname, string address, DateTime dateOfBirth)       
            => new User(id, username, email, password, name, surname, address, dateOfBirth);                            
    }
}
