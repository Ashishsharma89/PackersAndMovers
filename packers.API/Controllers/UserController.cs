using Microsoft.AspNetCore.Mvc;
using Packer.Application.DTOs;
using packers.Application.Interfaces.Users;
using packers.Domain.Entities;
using System.Net;
using System.Threading.Tasks;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    private readonly IUserServices _userService;
    public UserController(IUserServices userService)
    {
        _userService = userService;
    }
    [HttpGet("profile")]
    public IActionResult Profile([FromQuery] int userId)
    {
        var user = InMemoryDb.Users.FirstOrDefault(u => u.Id == userId);
        if (user == null) return NotFound();
        return Ok(new { user.Id, user.Email, user.Name, user.Role });
    }

    [HttpPost("register-device-token")]
    public IActionResult RegisterDeviceToken([FromQuery] int userId, [FromBody] string deviceToken)
    {
        var user = InMemoryDb.Users.FirstOrDefault(u => u.Id == userId);
        if (user == null) return NotFound();
        user.DeviceToken = deviceToken;
        return Ok(new { message = "Device token registered." });
    }
    [HttpPost("customer-form-submit")]
    public async Task<IActionResult> CustomerFormSubmit([FromBody] CustomerFormSubmissionDto request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await _userService.CustomerFormSubmit(request);
        return Ok(new { Success = true, StatusCode = HttpStatusCode.OK, Message  = "Form submitted Succesfully"});
    }
} 