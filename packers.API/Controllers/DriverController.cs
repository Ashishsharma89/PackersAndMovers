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

        // Register a new driver
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterDriver([FromBody] DriverDto dto)
        {
            var driver = new Driver
            {
                Name = dto.Name,
                LicenseNumber = dto.LicenseNumber,
                Phone = dto.Phone,
                Status = dto.Status,
                CurrentLatitude = dto.CurrentLatitude,
                CurrentLongitude = dto.CurrentLongitude
            };
            await _driverService.AddDriverAsync(driver);
            return Ok(new { message = "Driver registered successfully.", driverId = driver.Id });
        }

        // Get all drivers
        [HttpGet("all")]
        public async Task<IActionResult> GetAllDrivers()
        {
            var drivers = await _driverService.GetAllDriversAsync();
            var driverDtos = drivers.Select(d => new Driver
            {
                Id=d.Id,
                Name = d.Name,
                LicenseNumber = d.LicenseNumber,
                Phone = d.Phone,
                Status = d.Status,
                CurrentLatitude = d.CurrentLatitude,
                CurrentLongitude = d.CurrentLongitude
            });
            return Ok(driverDtos);
        }

        // Get driver by ID (already exists)
        [HttpGet("{driverId}")]
        public async Task<ActionResult<DriverDto>> GetDriver(int driverId)
        {
            var driver = await _driverService.GetDriverByIdAsync(driverId);
            if (driver == null)
                return NotFound();
            var dto = new DriverDto
            {
                Name = driver.Name,
                LicenseNumber = driver.LicenseNumber,
                Phone = driver.Phone,
                Status = driver.Status,
                CurrentLatitude = driver.CurrentLatitude,
                CurrentLongitude = driver.CurrentLongitude
            };
            return Ok(dto);
        }

        // Update driver
        [HttpPut("{driverId}")]
        public async Task<IActionResult> UpdateDriver(int driverId, [FromBody] DriverDto dto)
        {
            var driver = await _driverService.GetDriverByIdAsync(driverId);
            if (driver == null)
                return NotFound();

            driver.Name = dto.Name;
            driver.LicenseNumber = dto.LicenseNumber;
            driver.Phone = dto.Phone;
            driver.Status = dto.Status;
            driver.CurrentLatitude = dto.CurrentLatitude;
            driver.CurrentLongitude = dto.CurrentLongitude;

            await _driverService.UpdateDriverAsync(driver);
            return Ok(new { message = "Driver updated successfully." });
        }

        // Delete driver
        [HttpDelete("{driverId}")]
        public async Task<IActionResult> DeleteDriver(int driverId)
        {
            var driver = await _driverService.GetDriverByIdAsync(driverId);
            if (driver == null)
                return NotFound();

            await _driverService.DeleteDriverAsync(driverId);
            return Ok(new { message = "Driver deleted successfully." });
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