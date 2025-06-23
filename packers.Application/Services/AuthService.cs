using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;
using Packer.Application.Config;
using Packer.Domain.Entities;
using Packer.Application.DTOs;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Packer.Application.Interfaces.Auth;
using Packer.Application.Interfaces.Repository;
using Packer.Application.Interfaces.Conmmunication;

namespace Packer.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtConfig _jwtConfig;
        private readonly IEmailService _emailService;
        private readonly IResetTokenRepository _resetTokenRepository;

        public AuthService(
            IUserRepository userRepository,
            IOptions<JwtConfig> jwtConfig,
            IEmailService emailService,
            IResetTokenRepository resetTokenRepository)
        {
            _userRepository = userRepository;
            _jwtConfig = jwtConfig.Value;
            _emailService = emailService;
            _resetTokenRepository = resetTokenRepository;
        }

        public async Task<AuthResponseDto> LoginAsync(LoginRequestDto request)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user == null)
                throw new Exception("User not found");

            var passwordHash = GeneratePasswordHash(request.Password);
            if (user.PasswordHash != passwordHash)
                throw new Exception("Invalid password");

            return new AuthResponseDto
            {
                Token = await GenerateJwtToken(user),
                Email = user.Email,
                Role = user.Role
            };
        }

        public async Task<bool> RegisterAsync(RegisterDto request)
        {
            var existingUser = await _userRepository.GetByEmailAsync(request.Email);
            if (existingUser != null)
                throw new Exception("Email already registered");

            // Create new user with IsVerified = false
            var user = new User
            {
                Name = request.Name,
                Email = request.Email,
                PasswordHash = GeneratePasswordHash(request.Password),
                Role = "User",
                IsVerified = false
            };

            await _userRepository.AddAsync(user);

            // Generate a 6-digit OTP
            var otp = GenerateOtp();
            
            // Save the OTP with expiration time (1 hour)
            await _resetTokenRepository.AddResetTokenAsync(request.Email, otp);

            // Send OTP via email
            var message = new EmailMessage
            {
                To = request.Email,
                Subject = "Account Verification OTP",
                Body = $@"
                    <h2>Account Verification</h2>
                    <p>Your OTP for account verification is:</p>
                    <p><strong>{otp}</strong></p>
                    <p>This OTP will expire in 1 hour.</p>
                    <p>If you did not request this registration, please ignore this email.</p>",
                IsHtml = true
            };

            await _emailService.SendEmailAsync(message);
            return true;
        }

        public async Task<AuthResponseDto> VerifyOtpAsync(VerifyOtpDto request)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user == null)
                throw new Exception("User not found");

            if (user.IsVerified)
                throw new Exception("User is already verified");

            var isValidToken = await _resetTokenRepository.GetUserByValidTokenAsync(request.Email, request.Otp);
            if (isValidToken == null)
                throw new Exception("Invalid or expired OTP");

            // Mark OTP as used
            await _resetTokenRepository.MarkTokenAsUsedAsync(request.Email, request.Otp);

            // Mark user as verified
            user.IsVerified = true;
            await _userRepository.UpdateAsync(user);

            return new AuthResponseDto
            {
                Token = await GenerateJwtToken(user),
                Email = user.Email,
                Role = user.Role
            };
        }

        public async Task<bool> ChangePasswordAsync(int userId, string currentPassword, string newPassword)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
                throw new Exception("User not found");

            var currentPasswordHash = GeneratePasswordHash(currentPassword);
            if (user.PasswordHash != currentPasswordHash)
                throw new Exception("Current password is incorrect");

            var newPasswordHash = GeneratePasswordHash(newPassword);
            if (user.PasswordHash == newPasswordHash)
                throw new Exception("New password cannot be the same as your current password");

            user.PasswordHash = newPasswordHash;
            await _userRepository.UpdateAsync(user);
            return true;
        }

        public async Task<bool> ResetPasswordAsync(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null)
                throw new Exception("User not found");

            // Generate a random reset token
            var resetToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
            
            // Save the token
            await _resetTokenRepository.AddResetTokenAsync(email, resetToken);

            // Send reset token via email
            var message = new EmailMessage
            {
                To = email,
                Subject = "Password Reset Request",
                Body = $@"
                    <h2>Password Reset Request</h2>
                    <p>You have requested to reset your password. Please use the following token to reset your password:</p>
                    <p><strong>{resetToken}</strong></p>
                    <p>This token will expire in 1 hour.</p>
                    <p>If you did not request this password reset, please ignore this email.</p>",
                IsHtml = true
            };

            await _emailService.SendEmailAsync(message);
            return true;
        }

        public async Task<bool> SetNewPasswordAsync(string email, string resetToken, string newPassword)
        {
            var user = await _resetTokenRepository.GetUserByValidTokenAsync(email, resetToken);

            if (user == null)
                throw new Exception("Invalid or expired reset token");

            var newPasswordHash = GeneratePasswordHash(newPassword);
            if (user.PasswordHash == newPasswordHash)
                throw new Exception("New password cannot be the same as your current password");

            // Mark token as used
            await _resetTokenRepository.MarkTokenAsUsedAsync(email, resetToken);

            // Update password
            user.PasswordHash = newPasswordHash;
            await _userRepository.UpdateAsync(user);

            return true;
        }

        public async Task<string> GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtConfig.Key);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddMinutes(_jwtConfig.DurationInMinutes),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature),
                Issuer = _jwtConfig.Issuer,
                Audience = _jwtConfig.Audience
            };

            var token = await Task.Run(() => tokenHandler.CreateToken(tokenDescriptor));
            return tokenHandler.WriteToken(token);
        }

        public bool ValidatePassword(string password, string passwordHash)
        {
            return GeneratePasswordHash(password) == passwordHash;
        }

        private string GeneratePasswordHash(string password)
        {
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedBytes);
        }

        private string GenerateOtp()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }
    }
} 