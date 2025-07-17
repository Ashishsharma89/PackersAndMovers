using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Packer.Application.DTOs;
using packers.Application.Interfaces.Users;
using packers.Infrastructure.Data;
using System.Net;

[ApiController]
[Route("api/user")]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IUserServices _userService;
    private readonly ApplicationDbContext _dbContext;

    public UserController(ApplicationDbContext dbContext,IUserServices userService)
    {
        _dbContext = dbContext;
        _userService = userService;
    }

    [HttpGet("profile")]
    [Authorize]
    public IActionResult Profile([FromQuery] int userId)
    {
        var user = _dbContext.Users.FirstOrDefault(u => u.Id == userId);
        if (user == null) return NotFound();
        return Ok(new { user.Id, user.Email, user.Name, user.Role });
    }

    [HttpPost("register-device-token")]
    [AllowAnonymous]
    public IActionResult RegisterDeviceToken([FromQuery] int userId, [FromBody] string deviceToken)
    {
        var user = _dbContext.Users.FirstOrDefault(u => u.Id == userId);
        if (user == null) return NotFound();
        user.DeviceToken = deviceToken;
        _dbContext.SaveChanges();
        return Ok(new { message = "Device token registered." });
    }
    [HttpPost("customer-form-submit")]
    [AllowAnonymous]
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