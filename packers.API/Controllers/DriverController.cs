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
    public class DriverController : ControllerBase
    {
        private readonly IDriverService _driverService;
        public DriverController(IDriverService driverService)
        {
            _driverService = driverService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDriver([FromBody] CreateDriverWithTruckDto dto)
        {
            try
            {
                var driver = await _driverService.AddDriverWithTruckAsync(dto);
                return CreatedAtAction(nameof(GetDriverById), new { id = driver.Id }, driver);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDrivers()
        {
            var drivers = await _driverService.GetAllDriversAsync();
            return Ok(drivers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDriverById(int id)
        {
            var driver = await _driverService.GetDriverByIdAsync(id);
            if (driver == null)
                return NotFound();
            return Ok(driver);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDriver(int id, [FromBody] UpdateDriverWithTruckDto dto)
        {
            try
            {
                var updated = await _driverService.UpdateDriverWithTruckAsync(id, dto);
                if (updated == null)
                    return NotFound();

                return Ok(updated);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDriver(int id)
        {
            var result = await _driverService.DeleteDriverAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }

        // Update location (already exists)
        [HttpPost("update-location")]
        public async Task<IActionResult> UpdateLocation([FromBody] DriverLocationUpdateDto dto)
        {
            await _driverService.UpdateDriverLocationAsync(dto.DriverId, dto.Latitude, dto.Longitude);
            return Ok(new { dto.DriverId, message = "Location updated." });
        }
    }
}