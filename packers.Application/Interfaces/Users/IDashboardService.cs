using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace packers.Application.Interfaces.Users
{
    public class DashboardStatsDto
    {
        public int TotalCustomers { get; set; }
        public int TotalDrivers { get; set; }
        public int TotalTrucks { get; set; }
        public int TotalOrders { get; set; }
        public double AverageDeliveryTime { get; set; }
        public decimal TotalRevenue { get; set; }
    }

    public class TopCustomerDto
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public int OrderCount { get; set; }
        public decimal TotalSpent { get; set; }
    }

    public class MonthlyTrendDto
    {
        public string Month { get; set; } = string.Empty;
        public int OrderCount { get; set; }
        public decimal Revenue { get; set; }
        public double AverageDeliveryTime { get; set; }
    }

    public interface IDashboardService
    {
        Task<DashboardStatsDto> GetDashboardStatsAsync();
        Task<List<TopCustomerDto>> GetTopCustomersAsync(int count = 5);
        Task<List<MonthlyTrendDto>> GetMonthlyTrendsAsync(int months = 12);
    }
} 