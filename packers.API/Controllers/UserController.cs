using Microsoft.AspNetCore.Mvc;
using Packer.Domain.Entities;

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
} 