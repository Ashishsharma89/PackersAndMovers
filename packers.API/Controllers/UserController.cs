using Microsoft.AspNetCore.Mvc;
using packers.Domain.Entities;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
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
} 