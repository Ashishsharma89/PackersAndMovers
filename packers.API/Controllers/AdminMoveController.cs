using Microsoft.AspNetCore.Mvc;
using Packer.Domain.Entities;

[ApiController]
[Route("api/admin/move")]
public class AdminMoveController : ControllerBase
{
    [HttpGet("requests")]
    public IActionResult GetAllMoves()
    {
        return Ok(InMemoryDb.Moves);
    }

    [HttpPut("request/{id}/status")]
    public IActionResult UpdateStatus(int id, [FromBody] string status)
    {
        var move = InMemoryDb.Moves.FirstOrDefault(m => m.Id == id);
        if (move == null) return NotFound();
        move.Status = status;
        return Ok(move);
    }
} 