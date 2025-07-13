using packers.Application.DTOs;
using packers.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace packers.Application.Interfaces.Auth
{
    public interface IAuthService
    {
        Task<AuthResponseDto> LoginAsync(LoginRequestDto request);
        Task<bool> RegisterAsync(RegisterDto request);
        Task<AuthResponseDto> VerifyOtpAsync(VerifyOtpDto request);
        Task<bool> ChangePasswordAsync(int userId, string currentPassword, string newPassword);
        Task<bool> ResetPasswordAsync(string email);
        Task<bool> SetNewPasswordAsync(string email, string resetToken, string newPassword);
        Task<string> GenerateJwtToken(User user);
        bool ValidatePassword(string password, string passwordHash);
    }
}