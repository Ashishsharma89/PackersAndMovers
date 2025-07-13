using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using packers.Domain.Entities;

namespace packers.Application.Interfaces.Users
{
    public interface IDriverService
    {
        Task<Driver?> GetDriverByIdAsync(Guid id);
        Task<IEnumerable<Driver>> GetAllDriversAsync();
        Task AddDriverAsync(Driver driver);
        Task UpdateDriverAsync(Driver driver);
        Task DeleteDriverAsync(Guid id);
        Task UpdateDriverLocationAsync(Guid driverId, double latitude, double longitude);
    }
} 