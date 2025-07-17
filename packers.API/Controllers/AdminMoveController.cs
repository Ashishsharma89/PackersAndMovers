using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using packers.Infrastructure.Data;

[ApiController]
[Route("api/admin/move")]
[Authorize]
public class AdminMoveController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;

    public AdminMoveController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
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
} 