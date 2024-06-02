namespace TaxiApp.Application.Abstractions
{
    public interface IPasswordHasher
    {
        bool VerifyPassword(string passwordHash, string inputPassword);
        string Hash(string password);
    }
}
