using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using packers.Application.DTOs;
using packers.Application.Interfaces.Users;

namespace packers.API.Controllers
{
    [ApiController]
    [Route("api/move")]
    [Authorize]
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

        [HttpGet("items")]
        public IActionResult GetAvailableItems()
        {
            var items = new List<string>
            {
                "Furniture",
                "Electronics",
                "Clothing",
                "Books",
                "Kitchen Items",
                "Bedding",
                "Appliances",
                "Sports Equipment",
                "Musical Instruments",
                "Artwork"
            };
            return Ok(items);
        }

        [HttpGet("services")]
        public IActionResult GetAvailableServices()
        {
            var services = new List<string>
            {
                "Packing",
                "Loading",
                "Unloading",
                "Assembly",
                "Disassembly",
                "Storage",
                "Insurance",
                "Express Delivery",
                "Weekend Service",
                "Climate Control"
            };
            return Ok(services);
        }

        [HttpGet("route")]
        public IActionResult GetRoute([FromQuery] string origin, [FromQuery] string destination)
        {
            // This would integrate with Google Maps API in a real implementation
            var mockRoute = new
            {
                Origin = origin,
                Destination = destination,
                Distance = "25.5 km",
                Duration = "45 minutes",
                EstimatedCost = 1500.00m
            };
            return Ok(mockRoute);
        }
    }
} 