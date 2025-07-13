using System;

namespace packers.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Role { get; set; } = "User"; // "User" or "Admin"
        public int Age { get; set; }
        public bool IsVerified { get; set; } = false;

        // Reset Token properties
        public string? ResetToken { get; set; }
        public DateTime? ResetTokenExpiry { get; set; }
        public bool IsResetTokenUsed { get; set; }

        // Device token for push notifications
        public string? DeviceToken { get; set; }

        public User()
        {
        }

        public User(string firstName, string lastName, string email, int age)
        {
            Name = $"{firstName} {lastName}";
            Email = email;
            Age = age;
            Role = "User";
            PasswordHash = string.Empty; // Will be set separately
        }

        public string GetFullName()
        {
            return Name;
        }
    }
} 