using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using packers.Application.DTOs;
using packers.Application.Interfaces.Users;
using packers.Domain.Entities;

namespace packers.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TruckController : ControllerBase
    {
        private readonly ITruckService _truckService;
        public TruckController(ITruckService truckService)
        {
            _truckService = truckService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var trucks = await _truckService.GetAllTrucksAsync();
            return Ok(trucks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var truck = await _truckService.GetTruckByIdAsync(id);
            if (truck == null) return NotFound();
            return Ok(truck);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TruckDto truck)
        {
            var created = await _truckService.CreateTruckAsync(truck);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Truck truck)
        {
            if (id != truck.Id) return BadRequest();
            var updated = await _truckService.UpdateTruckAsync(truck);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _truckService.DeleteTruckAsync(id);
            return NoContent();
        }

        [HttpGet("by-number/{truckNumber}")]
        public async Task<IActionResult> GetByTruckNumber(string truckNumber)
        {
            var truck = await _truckService.GetTruckByTruckNumberAsync(truckNumber);
            if (truck == null) return NotFound();
            return Ok(truck);
        }

        [HttpGet("by-status/{status}")]
        public async Task<IActionResult> GetByStatus(string status)
        {
            var trucks = await _truckService.GetTrucksByStatusAsync(status);
            return Ok(trucks);
        }
    }
} 