using packers.Application.DTOs;
using packers.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace packers.Application.Interfaces.Repository
{
    public interface IDriverRepository
    {
        Task<Driver> AddDriverWithTruckAsync(CreateDriverWithTruckDto dto);
        Task<Driver?> GetDriverByIdAsync(int id);
        Task<IEnumerable<Driver>> GetAllDriversAsync();
        Task<Driver?> UpdateDriverWithTruckAsync(int id, UpdateDriverWithTruckDto dto);
        Task<bool> DeleteDriverAsync(int id);
        Task UpdateLocationAsync(int driverId, double latitude, double longitude);
        Task<Driver?> GetFirstAvailableDriverAsync();
        Task<Driver?> AssignDriverToOrderAsync(int orderId);
        Task<bool> UpdateOrderStatusAndFreeDriverAsync(int orderId, string orderStatus);
    }
} 