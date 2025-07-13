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
    public class TrackingEventRepository : ITrackingEventRepository
    {
        private readonly ApplicationDbContext _context;
        public TrackingEventRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TrackingEvent?> GetByIdAsync(Guid id)
        {
            return await _context.TrackingEvents.FindAsync(id);
        }

        public async Task<IEnumerable<TrackingEvent>> GetByShipmentIdAsync(Guid shipmentId)
        {
            return await _context.TrackingEvents.Where(e => e.ShipmentId == shipmentId).ToListAsync();
        }

        public async Task AddAsync(TrackingEvent trackingEvent)
        {
            await _context.TrackingEvents.AddAsync(trackingEvent);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TrackingEvent>> GetAllAsync()
        {
            return await _context.TrackingEvents.ToListAsync();
        }
    }
} 