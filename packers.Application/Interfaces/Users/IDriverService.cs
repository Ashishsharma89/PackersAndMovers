using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using packers.Domain.Entities;

namespace packers.Application.Interfaces.Users
{
    public interface IDriverService
    {
        Task<Driver?> GetDriverByIdAsync(int id);
        Task<IEnumerable<Driver>> GetAllDriversAsync();
        Task AddDriverAsync(Driver driver);
        Task UpdateDriverAsync(Driver driver);
        Task DeleteDriverAsync(int id);
        Task UpdateDriverLocationAsync(int driverId, double latitude, double longitude);
    }
} 