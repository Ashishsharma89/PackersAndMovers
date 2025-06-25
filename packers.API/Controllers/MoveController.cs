using Microsoft.AspNetCore.Mvc;
using packers.Application.DTOs; 
using packers.Application.Interfaces.Users;

[ApiController]
[Route("api/move")]
public class MoveController : ControllerBase
{
    private readonly IMoveService _moveService;
    public MoveController(IMoveService moveService)
    {
        _moveService = moveService;
    }

    [HttpPost("request/quote")]
    public async Task<IActionResult> GetInstantQuote([FromBody] MoveRequestDto dto)
    {
        var price = await _moveService.GetInstantQuoteAsync(dto);
        return Ok(new { estimatedPrice = price });
    }

    [HttpPost("request")]
    public async Task<IActionResult> CreateMove([FromBody] MoveRequestDto dto, [FromQuery] int userId)
    {
        var move = await _moveService.CreateMoveAsync(dto, userId);
        return Ok(move);
    }

    [HttpGet("requests")]
    public async Task<IActionResult> GetMyMoves([FromQuery] int userId)
    {
        var moves = await _moveService.GetUserMovesAsync(userId);
        return Ok(moves);
    }

    [HttpGet("request/{id}")]
    public async Task<IActionResult> GetMove(int id, [FromQuery] int userId)
    {
        var move = await _moveService.GetMoveByIdAsync(id, userId);
        if (move == null) return NotFound();
        return Ok(move);
    }

    [HttpPut("request/{id}")]
    public async Task<IActionResult> UpdateMove(int id, [FromBody] MoveRequestDto dto, [FromQuery] int userId)
    {
        var move = await _moveService.UpdateMoveAsync(id, dto, userId);
        if (move == null) return NotFound();
        return Ok(move);
    }

    [HttpDelete("request/{id}")]
    public async Task<IActionResult> DeleteMove(int id, [FromQuery] int userId)
    {
        await _moveService.DeleteMoveAsync(id, userId);
        return Ok("Deleted");
    }
} 