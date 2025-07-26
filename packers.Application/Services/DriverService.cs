using packers.Application.DTOs;
using packers.Application.Interfaces.Repository;
using packers.Application.Interfaces.Users;
using packers.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace packers.Application.Services
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepository;
        public DriverService(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        public async Task<Driver> AddDriverWithTruckAsync(CreateDriverWithTruckDto dto)
        {
            return await _driverRepository.AddDriverWithTruckAsync(dto);
        }

        public async Task<Driver?> GetDriverByIdAsync(int id)
        {
            return await _driverRepository.GetDriverByIdAsync(id);
        }

        public async Task<IEnumerable<Driver>> GetAllDriversAsync()
        {
            return await _driverRepository.GetAllDriversAsync();
        }

        public async Task<Driver?> UpdateDriverWithTruckAsync(int id, UpdateDriverWithTruckDto dto)
        {
            return await _driverRepository.UpdateDriverWithTruckAsync(id, dto);
        }

        public async Task<bool> DeleteDriverAsync(int id)
        {
            return await _driverRepository.DeleteDriverAsync(id);
        }

        public async Task UpdateDriverLocationAsync(int driverId, double latitude, double longitude)
        {
            await _driverRepository.UpdateLocationAsync(driverId, latitude, longitude);
        }

        public async Task<AssignedDriverDto?> AssignDriverToOrderAsync(int orderId)
        {
            var driver = await _driverRepository.AssignDriverToOrderAsync(orderId);
            if (driver == null) return null;
            return new AssignedDriverDto
            {
                DriverId = driver.Id,
                Name = driver.Name,
                Phone = driver.Phone,
                Status = driver.Status
            };
        }

        public async Task<bool> UpdateOrderStatusAndFreeDriverAsync(int orderId, string orderStatus)
        {
            return await _driverRepository.UpdateOrderStatusAndFreeDriverAsync(orderId, orderStatus);
        }
    }
} 