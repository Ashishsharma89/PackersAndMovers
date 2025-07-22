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
    [HttpGet("get-all-customers")]
    [Authorize]
    public async Task<IActionResult> GetAllCustomers()
    {
        var customers = await _userService.GetAllCustomers();
        return Ok(customers);
    }
    [HttpGet("customers-by-date")]
    [AllowAnonymous]
    public async Task<IActionResult> GetCustomersByDate([FromQuery] DateTime date)
    {
        var customers = await _userService.GetCustomersByDateAsync(date);
        return Ok(customers);
    }
    [HttpGet("customer-by-id")]
    [AllowAnonymous]
    public async Task<IActionResult> GetCustomerById([FromQuery] int id)
    {
        var customer = await _userService.GetCustomerByIdAsync(id);
        return Ok(customer);
    }
    [HttpPut("update-customer-by-id")]
    [AllowAnonymous]
    public async Task<IActionResult> UpdateCustomerById([FromQuery] int id, [FromBody] string deliveryStatus)
    {
        var result = await _userService.UpdateCustomerDeliveryStatusAsync(id, deliveryStatus);
        if (!result)
            return NotFound();
        return Ok(new { Success = true, Message = "Customer updated successfully." });
    }
}