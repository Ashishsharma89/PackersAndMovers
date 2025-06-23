using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Packer.Application.DTOs;
using System.Security.Claims;
using Packer.Application.Interfaces.Auth;
using Packer.Application.Interfaces.Conmmunication;
using Packer.Domain.Entities;

namespace Packer.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IEmailService _emailService;

        public AuthController(IAuthService authService, IEmailService emailService)
        {
            _authService = authService;
            _emailService = emailService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterDto dto)
        {
            if (InMemoryDb.Users.Any(u => u.Email == dto.Email))
                return BadRequest("Email already exists.");
            var user = new User
            {
                Id = InMemoryDb.Users.Count + 1,
                Email = dto.Email,
                PasswordHash = dto.Password, // Hash in real app!
                Name = dto.Name,
                Role = "User"
            };
            InMemoryDb.Users.Add(user);
            return Ok("Registered!");
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto dto)
        {
            var user = InMemoryDb.Users.FirstOrDefault(u => u.Email == dto.Email && u.PasswordHash == dto.Password);
            if (user == null) return Unauthorized();
            // Return a fake token for demo
            return Ok(new { token = "fake-jwt-token", userId = user.Id, role = user.Role });
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
                if (userId == 0)
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