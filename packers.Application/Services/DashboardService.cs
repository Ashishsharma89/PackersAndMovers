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
        private readonly ICustomerRepository _customerRepository;
        private readonly IDriverRepository _driverRepository;
        private readonly ITruckRepository _truckRepository;
        private readonly IMoveRequestRepository _moveRequestRepository;

        public DashboardService(
            ICustomerRepository customerRepository,
            IDriverRepository driverRepository,
            ITruckRepository truckRepository,
            IMoveRequestRepository moveRequestRepository)
        {
            _customerRepository = customerRepository;
            _driverRepository = driverRepository;
            _truckRepository = truckRepository;
            _moveRequestRepository = moveRequestRepository;
        }

        public async Task<DashboardStatsDto> GetDashboardStatsAsync()
        {
            var customers = await _customerRepository.GetAllAsync();
            var drivers = await _driverRepository.GetAllAsync();
            var trucks = await _truckRepository.GetAllAsync();
            var orders = await _moveRequestRepository.GetAllAsync();

            return new DashboardStatsDto
            {
                TotalCustomers = customers.Count(),
                TotalDrivers = drivers.Count(),
                TotalTrucks = trucks.Count(),
                TotalOrders = orders.Count(),
                AverageDeliveryTime = CalculateAverageDeliveryTime(orders),
                TotalRevenue = orders.Sum(o => o.EstimatedPrice)
            };
        }

        public async Task<List<TopCustomerDto>> GetTopCustomersAsync(int count = 5)
        {
            var customers = await _customerRepository.GetAllAsync();
            var orders = await _moveRequestRepository.GetAllAsync();

            var topCustomers = customers
                .Select(c => new TopCustomerDto
                {
                    CustomerId = c.Id,
                    CustomerName = c.Name,
                    OrderCount = orders.Count(o => o.UserId == c.Id),
                    TotalSpent = orders.Where(o => o.UserId == c.Id).Sum(o => o.EstimatedPrice)
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