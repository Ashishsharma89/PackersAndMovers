using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using packers.Application.Interfaces.Repository;
using packers.Application.Interfaces.Users;
using packers.Domain.Entities;

namespace packers.Application.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IDriverRepository _driverRepository;
        private readonly IMoveRequestRepository _moveRequestRepository;

        public DashboardService(
            IDriverRepository driverRepository,
            IMoveRequestRepository moveRequestRepository)
        {
            _driverRepository = driverRepository;
            _moveRequestRepository = moveRequestRepository;
        }

        public async Task<DashboardStatsDto> GetDashboardStatsAsync()
        {
            var drivers = await _driverRepository.GetAllAsync();
            var orders = await _moveRequestRepository.GetAllAsync();

            return new DashboardStatsDto
            {
                TotalDrivers = drivers.Count(),
                TotalOrders = orders.Count(),
                AverageDeliveryTime = CalculateAverageDeliveryTime(orders),
                TotalRevenue = orders.Sum(o => o.EstimatedPrice)
            };
        }

        public async Task<List<TopCustomerDto>> GetTopCustomersAsync(int count = 5)
        {
            var orders = await _moveRequestRepository.GetAllAsync();

            var topCustomers = orders
                .Select(o => o.UserId)
                .Distinct()
                .Select(userId => new TopCustomerDto
                {
                    CustomerId = userId,
                    CustomerName = "Unknown Customer", // Placeholder, actual name would need to be fetched
                    OrderCount = orders.Count(o => o.UserId == userId),
                    TotalSpent = orders.Where(o => o.UserId == userId).Sum(o => o.EstimatedPrice)
                })
                .Where(c => c.OrderCount > 0)
                .OrderByDescending(c => c.OrderCount)
                .Take(count)
                .ToList();

            return topCustomers;
        }

        public async Task<List<MonthlyTrendDto>> GetMonthlyTrendsAsync(int months = 12)
        {
            var orders = await _moveRequestRepository.GetAllAsync();
            var trends = new List<MonthlyTrendDto>();

            for (int i = months - 1; i >= 0; i--)
            {
                var date = DateTime.UtcNow.AddMonths(-i);
                var monthOrders = orders.Where(o => 
                    o.MoveDate.Year == date.Year && 
                    o.MoveDate.Month == date.Month).ToList();

                trends.Add(new MonthlyTrendDto
                {
                    Month = date.ToString("MMMM yyyy"),
                    OrderCount = monthOrders.Count,
                    Revenue = monthOrders.Sum(o => o.EstimatedPrice),
                    AverageDeliveryTime = CalculateAverageDeliveryTime(monthOrders)
                });
            }

            return trends;
        }

        private double CalculateAverageDeliveryTime(IEnumerable<MoveRequest> orders)
        {
            // This is a simplified calculation
            // In a real application, you'd calculate actual delivery times
            var completedOrders = orders.Where(o => o.Status == "Completed");
            return completedOrders.Any() ? 2.5 : 0; // Default 2.5 hours average
        }
    }
} 