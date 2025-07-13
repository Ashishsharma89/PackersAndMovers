using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using packers.Domain.Entities;

namespace packers.Application.Interfaces.Users
{
    public interface ITruckService
    {
        Task<Truck?> GetTruckByIdAsync(Guid id);
        Task<IEnumerable<Truck>> GetAllTrucksAsync();
        Task<Truck> CreateTruckAsync(Truck truck);
        Task<Truck> UpdateTruckAsync(Truck truck);
        Task DeleteTruckAsync(Guid id);
        Task<Truck?> GetTruckByTruckNumberAsync(string truckNumber);
        Task<IEnumerable<Truck>> GetTrucksByStatusAsync(string status);
    }
} 