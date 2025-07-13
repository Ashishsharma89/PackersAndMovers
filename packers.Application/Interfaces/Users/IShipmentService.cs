using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using packers.Domain.Entities;

namespace packers.Application.Interfaces.Users
{
    public interface IShipmentService
    {
        Task<Shipment?> GetShipmentByIdAsync(int id);
        Task<IEnumerable<Shipment>> GetShipmentsByUserIdAsync(int userId);
        Task<IEnumerable<Shipment>> GetShipmentsByDriverIdAsync(int driverId);
        Task CreateShipmentAsync(Shipment shipment);
        Task UpdateShipmentAsync(Shipment shipment);
        Task DeleteShipmentAsync(int id);
        Task ConfirmDeliveryAsync(int shipmentId);
        Task<DateTime?> GetEstimatedArrivalAsync(int shipmentId);
    }
} 