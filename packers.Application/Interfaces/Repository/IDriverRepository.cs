using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using packers.Domain.Entities;

namespace packers.Application.Interfaces.Repository
{
    public interface IDriverRepository
    {
        Task<Driver?> GetByIdAsync(int id);
        Task<IEnumerable<Driver>> GetAllAsync();
        Task AddAsync(Driver driver);
        Task UpdateAsync(Driver driver);
        Task DeleteAsync(int id);
        Task UpdateLocationAsync(int driverId, double latitude, double longitude);
    }
} 