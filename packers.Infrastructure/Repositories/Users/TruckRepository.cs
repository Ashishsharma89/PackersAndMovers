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
    public class TruckRepository : ITruckRepository
    {
        private readonly ApplicationDbContext _context;
        public TruckRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Truck?> GetByIdAsync(Guid id)
        {
            return await _context.Trucks.FindAsync(id);
        }

        public async Task<IEnumerable<Truck>> GetAllAsync()
        {
            return await _context.Trucks.ToListAsync();
        }

        public async Task<Truck> AddAsync(Truck truck)
        {
            await _context.Trucks.AddAsync(truck);
            await _context.SaveChangesAsync();
            return truck;
        }

        public async Task<Truck> UpdateAsync(Truck truck)
        {
            _context.Trucks.Update(truck);
            await _context.SaveChangesAsync();
            return truck;
        }

        public async Task DeleteAsync(Guid id)
        {
            var truck = await _context.Trucks.FindAsync(id);
            if (truck != null)
            {
                _context.Trucks.Remove(truck);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Truck?> GetByTruckNumberAsync(string truckNumber)
        {
            return await _context.Trucks.FirstOrDefaultAsync(t => t.TruckNumber == truckNumber);
        }

        public async Task<IEnumerable<Truck>> GetByStatusAsync(string status)
        {
            return await _context.Trucks.Where(t => t.Status == status).ToListAsync();
        }
    }
} 