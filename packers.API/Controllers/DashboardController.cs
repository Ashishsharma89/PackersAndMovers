using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using packers.Application.Interfaces.Users;

namespace packers.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet("stats")]
        public async Task<IActionResult> GetDashboardStats()
        {
            var stats = await _dashboardService.GetDashboardStatsAsync();
            return Ok(stats);
        }

        [HttpGet("top-customers")]
        public async Task<IActionResult> GetTopCustomers([FromQuery] int count = 5)
        {
            var topCustomers = await _dashboardService.GetTopCustomersAsync(count);
            return Ok(topCustomers);
        }

        [HttpGet("monthly-trends")]
        public async Task<IActionResult> GetMonthlyTrends([FromQuery] int months = 12)
        {
            var trends = await _dashboardService.GetMonthlyTrendsAsync(months);
            return Ok(trends);
        }
    }
} 