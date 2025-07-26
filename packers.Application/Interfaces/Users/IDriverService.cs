using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using packers.Application.DTOs;
using packers.Domain.Entities;

namespace packers.Application.Interfaces.Users
{
    public interface IDriverService
    {
        Task<Driver> AddDriverWithTruckAsync(CreateDriverWithTruckDto dto);
        Task<Driver?> GetDriverByIdAsync(int id);
        Task<IEnumerable<Driver>> GetAllDriversAsync();
        Task<Driver?> UpdateDriverWithTruckAsync(int id, UpdateDriverWithTruckDto dto);
        Task<bool> DeleteDriverAsync(int id);
        Task UpdateDriverLocationAsync(int driverId, double latitude, double longitude);
        Task<AssignedDriverDto?> AssignDriverToOrderAsync(int orderId);
        Task<bool> UpdateOrderStatusAndFreeDriverAsync(int orderId, string orderStatus);
    }
} 