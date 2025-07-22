using Microsoft.EntityFrameworkCore;
using packers.Application.DTOs;
using packers.Application.Interfaces.Repository;
using packers.Domain.Entities;
using packers.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace packers.Infrastructure.Repositories.Users
{
    public class DriverRepository : IDriverRepository
    {
        private readonly ApplicationDbContext _context;
        public DriverRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Driver> AddDriverWithTruckAsync(CreateDriverWithTruckDto dto)
        {
            if (await _context.Trucks.AnyAsync(t => t.TruckNumber == dto.TruckNumber))
                throw new Exception("Truck number already exists.");

            var driver = new Driver
            {
                Name = dto.Name,
                LicenseNumber = dto.LicenseNumber,
                Phone = dto.Phone,
                CurrentLatitude = dto.CurrentLatitude,
                CurrentLongitude = dto.CurrentLongitude,
                Truck = new Truck { TruckNumber = dto.TruckNumber }
            };

            _context.Drivers.Add(driver);
            await _context.SaveChangesAsync();
            return driver;
        }

        public async Task<Driver?> GetDriverByIdAsync(int id)
        {
            return await _context.Drivers
                .Include(d => d.Truck)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<IEnumerable<Driver>> GetAllDriversAsync()
        {
            return await _context.Drivers
                .Include(d => d.Truck)
                .ToListAsync();
        }

        public async Task<Driver?> UpdateDriverWithTruckAsync(int id, UpdateDriverWithTruckDto dto)
        {
            var driver = await _context.Drivers.Include(d => d.Truck).FirstOrDefaultAsync(d => d.Id == id);
            if (driver == null)
                return null;

            if (driver.Truck.TruckNumber != dto.TruckNumber &&
                await _context.Trucks.AnyAsync(t => t.TruckNumber == dto.TruckNumber))
                throw new Exception("Truck number already assigned to another driver.");

            driver.Name = dto.Name;
            driver.LicenseNumber = dto.LicenseNumber;
            driver.Phone = dto.Phone;
            driver.CurrentLatitude = dto.CurrentLatitude;
            driver.CurrentLongitude = dto.CurrentLongitude;
            driver.Truck.TruckNumber = dto.TruckNumber;

            await _context.SaveChangesAsync();
            return driver;
        }

        public async Task<bool> DeleteDriverAsync(int id)
        {
            var driver = await _context.Drivers.Include(d => d.Truck).FirstOrDefaultAsync(d => d.Id == id);
            if (driver == null) return false;

            _context.Drivers.Remove(driver);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task UpdateLocationAsync(int driverId, double latitude, double longitude)
        {
            var driver = await _context.Drivers.FindAsync(driverId);
            if (driver != null)
            {
                driver.CurrentLatitude = latitude;
                driver.CurrentLongitude = longitude;
                _context.Drivers.Update(driver);
                await _context.SaveChangesAsync();
            }
        }
    }
} 