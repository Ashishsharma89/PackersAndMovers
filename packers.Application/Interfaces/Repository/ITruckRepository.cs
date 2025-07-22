using packers.Application.DTOs;
using packers.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace packers.Application.Interfaces.Repository
{
    public interface ITruckRepository
    {
        Task<Truck?> GetByIdAsync(int id);
        Task<IEnumerable<Truck>> GetAllAsync();
        Task<Truck> AddAsync(TruckDto truck);
        Task<Truck> UpdateAsync(Truck truck);
        Task DeleteAsync(int id);
        Task<Truck?> GetByTruckNumberAsync(string truckNumber);
        Task<IEnumerable<Truck>> GetByStatusAsync(string status);
    }
} 