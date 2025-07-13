using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using packers.Domain.Entities;

namespace packers.Application.Interfaces.Repository
{
    public interface ITruckRepository
    {
        Task<Truck?> GetByIdAsync(Guid id);
        Task<IEnumerable<Truck>> GetAllAsync();
        Task<Truck> AddAsync(Truck truck);
        Task<Truck> UpdateAsync(Truck truck);
        Task DeleteAsync(Guid id);
        Task<Truck?> GetByTruckNumberAsync(string truckNumber);
        Task<IEnumerable<Truck>> GetByStatusAsync(string status);
    }
} 