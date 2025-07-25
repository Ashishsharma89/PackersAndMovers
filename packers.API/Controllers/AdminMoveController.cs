using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using packers.Infrastructure.Data;
using packers.Application.Interfaces.Repository;
using packers.Domain.Entities;
using packers.Application.Interfaces.Users;
using packers.Application.DTOs;

[ApiController]
[Route("api/admin/move")]
[Authorize]
public class AdminMoveController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IDriverRepository _driverRepository;
    private readonly IDriverService _driverService;

    public AdminMoveController(ApplicationDbContext dbContext, IDriverRepository driverRepository, IDriverService driverService)
    {
        _dbContext = dbContext;
        _driverRepository = driverRepository;
        _driverService = driverService;
    }

    [HttpGet("requests")]
    public IActionResult GetAllMoves()
    {
        var moves = _dbContext.MoveRequests.ToList();
        return Ok(moves);
    }

    [HttpPut("request/{id}/status")]
    public IActionResult UpdateStatus(int id, [FromBody] string status)
    {
        var move = _dbContext.MoveRequests.FirstOrDefault(m => m.Id == id);
        if (move == null) return NotFound();
        move.Status = status;
        _dbContext.SaveChanges();
        return Ok(move);
    }

    [HttpPost("assign-driver/{orderId}")]
    public async Task<IActionResult> AssignDriverToOrder(int orderId)
    {
        var assignedDriver = await _driverService.AssignDriverToOrderAsync(orderId);
        if (assignedDriver == null)
            return NotFound("No available driver or order not found.");
        return Ok(assignedDriver);
    }
} 