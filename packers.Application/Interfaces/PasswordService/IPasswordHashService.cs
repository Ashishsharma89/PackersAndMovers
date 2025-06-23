namespace Packer.Application.Interfaces.PasswordHashing
{
    public interface IPasswordHashService
    {
        string HashPassword(string password);
        bool VerifyPassword(string hashedPassword, string password);
    }
}