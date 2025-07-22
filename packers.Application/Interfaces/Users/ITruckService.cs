using packers.Application.DTOs;
using packers.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace packers.Application.Interfaces.Users
{
    public interface ITruckService
    {
        Task<Truck?> GetTruckByIdAsync(int id);
        Task<IEnumerable<Truck>> GetAllTrucksAsync();
        Task<Truck> CreateTruckAsync(TruckDto truck);
        Task<Truck> UpdateTruckAsync(Truck truck);
        Task DeleteTruckAsync(int id);
        Task<Truck?> GetTruckByTruckNumberAsync(string truckNumber);
        Task<IEnumerable<Truck>> GetTrucksByStatusAsync(string status);
    }
} 