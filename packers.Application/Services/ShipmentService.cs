using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using packers.Application.Interfaces.Repository;
using packers.Application.Interfaces.Users;
using packers.Domain.Entities;

namespace packers.Application.Services
{
    public class ShipmentService : IShipmentService
    {
        private readonly IShipmentRepository _shipmentRepository;
        public ShipmentService(IShipmentRepository shipmentRepository)
        {
            _shipmentRepository = shipmentRepository;
        }

        public async Task<Shipment?> GetShipmentByIdAsync(int id)
        {
            return await _shipmentRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Shipment>> GetShipmentsByUserIdAsync(int userId)
        {
            return await _shipmentRepository.GetByUserIdAsync(userId);
        }

        public async Task<IEnumerable<Shipment>> GetShipmentsByDriverIdAsync(int driverId)
        {
            return await _shipmentRepository.GetByDriverIdAsync(driverId);
        }

        public async Task CreateShipmentAsync(Shipment shipment)
        {
            await _shipmentRepository.AddAsync(shipment);
        }

        public async Task UpdateShipmentAsync(Shipment shipment)
        {
            await _shipmentRepository.UpdateAsync(shipment);
        }

        public async Task DeleteShipmentAsync(int id)
        {
            await _shipmentRepository.DeleteAsync(id);
        }

        public async Task ConfirmDeliveryAsync(int shipmentId)
        {
            var shipment = await _shipmentRepository.GetByIdAsync(shipmentId);
            if (shipment != null)
            {
                shipment.DeliveryConfirmed = true;
                shipment.Status = ShipmentStatus.Delivered;
                await _shipmentRepository.UpdateAsync(shipment);
            }
        }

        public async Task<DateTime?> GetEstimatedArrivalAsync(int shipmentId)
        {
            var shipment = await _shipmentRepository.GetByIdAsync(shipmentId);
            return shipment?.EstimatedArrival;
        }
    }
} 