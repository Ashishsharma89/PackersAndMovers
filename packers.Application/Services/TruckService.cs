using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using packers.Application.Interfaces.Repository;
using packers.Application.Interfaces.Users;
using packers.Domain.Entities;

namespace packers.Application.Services
{
    public class TruckService : ITruckService
    {
        private readonly ITruckRepository _truckRepository;
        public TruckService(ITruckRepository truckRepository)
        {
            _truckRepository = truckRepository;
        }

        public async Task<Truck?> GetTruckByIdAsync(Guid id)
        {
            return await _truckRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Truck>> GetAllTrucksAsync()
        {
            return await _truckRepository.GetAllAsync();
        }

        public async Task<Truck> CreateTruckAsync(Truck truck)
        {
            truck.Id = Guid.NewGuid();
            truck.Status = "Available";
            return await _truckRepository.AddAsync(truck);
        }

        public async Task<Truck> UpdateTruckAsync(Truck truck)
        {
            return await _truckRepository.UpdateAsync(truck);
        }

        public async Task DeleteTruckAsync(Guid id)
        {
            await _truckRepository.DeleteAsync(id);
        }

        public async Task<Truck?> GetTruckByTruckNumberAsync(string truckNumber)
        {
            return await _truckRepository.GetByTruckNumberAsync(truckNumber);
        }

        public async Task<IEnumerable<Truck>> GetTrucksByStatusAsync(string status)
        {
            return await _truckRepository.GetByStatusAsync(status);
        }
    }
} 