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
        Task<IEnumerable<Driver>> GetAllDriversAsync();
        Task<Driver?> GetDriverByIdAsync(int id);
        Task<Driver?> UpdateDriverWithTruckAsync(int id, UpdateDriverWithTruckDto dto);
        Task<bool> DeleteDriverAsync(int id);
        Task UpdateLocationAsync(int driverId, double latitude, double longitude);
        Task<Driver?> AssignDriverToOrderAsync(int orderId);
    }
} 