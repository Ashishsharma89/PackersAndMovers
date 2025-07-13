using Microsoft.AspNetCore.Mvc;
using packers.Application.DTOs;
using packers.Application.Interfaces.Users;
using packers.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace packers.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriverController : ControllerBase
    {
        private readonly IDriverService _driverService;
        public DriverController(IDriverService driverService)
        {
            _driverService = driverService;
        }

        [HttpPost("update-location")]
        public async Task<IActionResult> UpdateLocation([FromBody] DriverLocationUpdateDto dto)
        {
            await _driverService.UpdateDriverLocationAsync(dto.DriverId, dto.Latitude, dto.Longitude);
            return Ok(new { dto.DriverId, message = "Location updated." });
        }

        [HttpGet("{driverId}")]
        public async Task<ActionResult<DriverDto>> GetDriver(Guid driverId)
        {
            var driver = await _driverService.GetDriverByIdAsync(driverId);
            if (driver == null)
                return NotFound();
            var dto = new DriverDto
            {
                Id = driver.Id,
                Name = driver.Name,
                CurrentLatitude = driver.CurrentLatitude,
                CurrentLongitude = driver.CurrentLongitude
            };
            return Ok(dto);
        }
    }
} 