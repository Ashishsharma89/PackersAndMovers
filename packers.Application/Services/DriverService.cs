using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using packers.Application.Interfaces.Repository;
using packers.Application.Interfaces.Users;
using packers.Domain.Entities;

namespace packers.Application.Services
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepository;
        public DriverService(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        public async Task<Driver?> GetDriverByIdAsync(Guid id)
        {
            return await _driverRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Driver>> GetAllDriversAsync()
        {
            return await _driverRepository.GetAllAsync();
        }

        public async Task AddDriverAsync(Driver driver)
        {
            await _driverRepository.AddAsync(driver);
        }

        public async Task UpdateDriverAsync(Driver driver)
        {
            await _driverRepository.UpdateAsync(driver);
        }

        public async Task DeleteDriverAsync(Guid id)
        {
            await _driverRepository.DeleteAsync(id);
        }

        public async Task UpdateDriverLocationAsync(Guid driverId, double latitude, double longitude)
        {
            await _driverRepository.UpdateLocationAsync(driverId, latitude, longitude);
        }
    }
} 