using Microsoft.AspNetCore.Mvc;
using Packer.Application.DTOs;
using Packer.Domain.Entities;

[ApiController]
[Route("api/move")]
public class MoveController : ControllerBase
{
    [HttpPost("request")]
    public IActionResult CreateMove([FromBody] MoveRequestDto dto, [FromQuery] int userId)
    {
        var move = new MoveRequest
        {
            Id = InMemoryDb.Moves.Count + 1,
            UserId = userId,
            SourceAddress = dto.SourceAddress,
            DestinationAddress = dto.DestinationAddress,
            MoveDate = dto.MoveDate,
            Items = string.Join(",", dto.Items),
            Status = "Pending",
            EstimatedPrice = 1000 + dto.Items.Count * 100 // Simple price logic
        };
        InMemoryDb.Moves.Add(move);
        return Ok(move);
    }

    [HttpGet("requests")]
    public IActionResult GetMyMoves([FromQuery] int userId)
    {
        var moves = InMemoryDb.Moves.Where(m => m.UserId == userId).ToList();
        return Ok(moves);
    }

    [HttpGet("request/{id}")]
    public IActionResult GetMove(int id, [FromQuery] int userId)
    {
        var move = InMemoryDb.Moves.FirstOrDefault(m => m.Id == id && m.UserId == userId);
        if (move == null) return NotFound();
        return Ok(move);
    }

    [HttpPut("request/{id}")]
    public IActionResult UpdateMove(int id, [FromBody] MoveRequestDto dto, [FromQuery] int userId)
    {
        var move = InMemoryDb.Moves.FirstOrDefault(m => m.Id == id && m.UserId == userId);
        if (move == null) return NotFound();
        move.SourceAddress = dto.SourceAddress;
        move.DestinationAddress = dto.DestinationAddress;
        move.MoveDate = dto.MoveDate;
        move.Items = string.Join(",", dto.Items);
        return Ok(move);
    }

    [HttpDelete("request/{id}")]
    public IActionResult DeleteMove(int id, [FromQuery] int userId)
    {
        var move = InMemoryDb.Moves.FirstOrDefault(m => m.Id == id && m.UserId == userId);
        if (move == null) return NotFound();
        InMemoryDb.Moves.Remove(move);
        return Ok("Deleted");
    }
} 