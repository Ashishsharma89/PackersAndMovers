using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using packers.Domain.Entities;

namespace packers.Application.Interfaces.Repository
{
    public interface IShipmentRepository
    {
        Task<Shipment?> GetByIdAsync(int id);
        Task<IEnumerable<Shipment>> GetAllAsync();
        Task AddAsync(Shipment shipment);
        Task UpdateAsync(Shipment shipment);
        Task DeleteAsync(int id);
        Task<IEnumerable<Shipment>> GetByUserIdAsync(int userId);
        Task<IEnumerable<Shipment>> GetByDriverIdAsync(int driverId);
    }
} 