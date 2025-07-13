using Microsoft.AspNetCore.Mvc;
using packers.Domain.Entities;
using packers.Application.Interfaces.Repository;
using System.Security.Cryptography;

namespace Packer.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IResetTokenRepository _resetTokenRepository;
        private readonly IUserRepository _userRepository;

        public TestController(IResetTokenRepository resetTokenRepository, IUserRepository userRepository)
        {
            _resetTokenRepository = resetTokenRepository;
            _userRepository = userRepository;
        }

        [HttpPost("test-reset-token")]
        public async Task<IActionResult> TestResetToken()
        {
            try
            {
                // 1. First create a test user
                var user = new User
                {
                    Name = "Test User",
                    Email = "test@example.com",
                    PasswordHash = "hashedpassword",
                    Age = 25,
                    Role = "User"
                };

                await _userRepository.AddAsync(user);

                // 2. Generate and add reset token
                string resetToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
                var userWithToken = await _resetTokenRepository.AddResetTokenAsync(user.Email, resetToken);
                
                // 3. Verify the token can be retrieved
                var userWithValidToken = await _resetTokenRepository.GetUserByValidTokenAsync(user.Email, resetToken);
                
                if (userWithValidToken == null)
                {
                    return BadRequest("Failed to retrieve token");
                }

                // 4. Mark token as used
                await _resetTokenRepository.MarkTokenAsUsedAsync(user.Email, resetToken);

                // 5. Verify the token is now invalid
                var userWithInvalidToken = await _resetTokenRepository.GetUserByValidTokenAsync(user.Email, resetToken);
                
                if (userWithInvalidToken != null)
                {
                    return BadRequest("Token should be invalid but is still valid");
                }

                return Ok(new
                {
                    message = "Reset token flow test completed successfully",
                    userId = user.Id,
                    email = user.Email,
                    token = resetToken
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
} 