namespace TaxiApp.WebApi.Models.User
{
    public abstract class UserRequest
    {
        public string Username { get; set; }        
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
