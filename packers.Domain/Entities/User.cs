namespace Packer.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Name { get; set; }
        public string Role { get; set; } // "User" or "Admin"
        public int Age { get; set; }
        public bool IsVerified { get; set; } = false;

        // Reset Token properties
        public string? ResetToken { get; set; }
        public DateTime? ResetTokenExpiry { get; set; }
        public bool IsResetTokenUsed { get; set; }

        public User()
        {
        }

        public User(string firstName, string lastName, string email, int age)
        {
            Name = $"{firstName} {lastName}";
            Email = email;
            Age = age;
        }

        public string GetFullName()
        {
            return Name;
        }
    }
} 