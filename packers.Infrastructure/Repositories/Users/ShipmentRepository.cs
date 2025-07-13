using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using packers.Application.Interfaces.Repository;
using packers.Domain.Entities;
using packers.Infrastructure.Data;

namespace packers.Infrastructure.Repositories.Users
{
    public class ShipmentRepository : IShipmentRepository
    {
        private readonly ApplicationDbContext _context;
        public ShipmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Shipment?> GetByIdAsync(Guid id)
        {
            return await _context.Shipments.FindAsync(id);
        }

        public async Task<IEnumerable<Shipment>> GetAllAsync()
        {
            return await _context.Shipments.ToListAsync();
        }

        public async Task AddAsync(Shipment shipment)
        {
            await _context.Shipments.AddAsync(shipment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Shipment shipment)
        {
            _context.Shipments.Update(shipment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var shipment = await _context.Shipments.FindAsync(id);
            if (shipment != null)
            {
                _context.Shipments.Remove(shipment);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Shipment>> GetByUserIdAsync(Guid userId)
        {
            return await _context.Shipments.Where(s => s.UserId == userId).ToListAsync();
        }

        public async Task<IEnumerable<Shipment>> GetByDriverIdAsync(Guid driverId)
        {
            return await _context.Shipments.Where(s => s.DriverId == driverId).ToListAsync();
        }
    }
} 