using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Packer.Application.Config;
using packers.Application.DTOs;
using packers.Application.Interfaces.Auth;
using packers.Application.Interfaces.Conmmunication;
using packers.Domain.Entities;
using packers.Infrastructure.Data;
using System.Security.Claims;

namespace packers.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IEmailService _emailService;
        private readonly ApplicationDbContext _dbContext;
        public AuthController(IAuthService authService, IEmailService emailService, ApplicationDbContext dbContext)
        {
            _authService = authService;
            _emailService = emailService;
            _dbContext = dbContext;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterDto dto)
        {
            if (_dbContext.Users.Any(u => u.Email == dto.Email))
                return BadRequest("Email already exists.");

            var user = new User
            {
                Email = dto.Email,
                PasswordHash = PasswordHelper.HashPassword(dto.Password), // Hash in real app!
                Name = dto.Name,
                Role = "User",
                Age = dto.Age,
                IsVerified = false
            };

            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            return Ok("Registered!");
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto dto)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == dto.Email);
            if (user == null) // Ensure user is not null before accessing its properties
                return Unauthorized();

            // Hash the password only after ensuring user is not null
            user.PasswordHash = PasswordHelper.HashPassword(dto.Password);
            bool isValid = PasswordHelper.VerifyPassword(dto.Password, user.PasswordHash);
            // Verify the password using your hashing helper or IAuthService
            if (!isValid)
                return Unauthorized();

            // Generate a JWT token (replace with your actual implementation)
            var token = _authService.GenerateJwtToken(user);

            return Ok(new { token, userId = user.Id, role = user.Role });
        }

        [HttpPost("verify-otp")]
        public async Task<IActionResult> VerifyOtp([FromBody] VerifyOtpDto request)
        {
            try
            {
                var response = await _authService.VerifyOtpAsync(request);
                return Ok(new { success = true, message = "Account verified and registered successfully", data = response });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [Authorize]
        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto request)
        {
            try
            {
                var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "0");
                if (userId == 0) // Replace int.Empty with 0
                    return Unauthorized();

                var result = await _authService.ChangePasswordAsync(userId, request.CurrentPassword, request.NewPassword);
                return Ok(new { success = true, message = "Password changed successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [HttpPost("reset-password-request")]
        public async Task<IActionResult> RequestPasswordReset([FromBody] ResetPasswordRequestDto request)
        {
            try
            {
                await _authService.ResetPasswordAsync(request.Email);
                return Ok(new { success = true, message = "Password reset instructions have been sent to your email." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] SetNewPasswordDto request)
        {
            try
            {
                await _authService.SetNewPasswordAsync(request.Email, request.ResetToken, request.NewPassword);
                return Ok(new { success = true, message = "Password has been reset successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }
    }
}