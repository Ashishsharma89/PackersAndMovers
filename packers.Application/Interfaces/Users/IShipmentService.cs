using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using packers.Domain.Entities;

namespace packers.Application.Interfaces.Users
{
    public interface IShipmentService
    {
        Task<Shipment?> GetShipmentByIdAsync(Guid id);
        Task<IEnumerable<Shipment>> GetShipmentsByUserIdAsync(Guid userId);
        Task<IEnumerable<Shipment>> GetShipmentsByDriverIdAsync(Guid driverId);
        Task CreateShipmentAsync(Shipment shipment);
        Task UpdateShipmentAsync(Shipment shipment);
        Task DeleteShipmentAsync(Guid id);
        Task ConfirmDeliveryAsync(Guid shipmentId);
        Task<DateTime?> GetEstimatedArrivalAsync(Guid shipmentId);
    }
} 