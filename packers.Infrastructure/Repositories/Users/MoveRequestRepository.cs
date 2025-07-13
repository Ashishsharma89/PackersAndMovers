using packers.Application.Interfaces.Repository;
using packers.Domain.Entities;
using packers.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace packers.Infrastructure.Repositories.Users
{
    public class MoveRequestRepository : IMoveRequestRepository
    {
        private readonly ApplicationDbContext _context;
        public MoveRequestRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<MoveRequest> AddAsync(MoveRequest moveRequest)
        {
            _context.MoveRequests.Add(moveRequest);
            await _context.SaveChangesAsync();
            return moveRequest;
        }

        public async Task<MoveRequest> UpdateAsync(MoveRequest moveRequest)
        {
            _context.MoveRequests.Update(moveRequest);
            await _context.SaveChangesAsync();
            return moveRequest;
        }

        public async Task DeleteAsync(int id)
        {
            var move = await _context.MoveRequests.FindAsync(id);
            if (move != null)
            {
                _context.MoveRequests.Remove(move);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<MoveRequest?> GetByIdAsync(int id)
        {
            return await _context.MoveRequests.FindAsync(id);
        }

        public async Task<List<MoveRequest>> GetByUserIdAsync(int userId)
        {
            return await _context.MoveRequests.Where(m => m.UserId == userId).ToListAsync();
        }

        public async Task<List<MoveRequest>> GetAllAsync()
        {
            return await _context.MoveRequests.ToListAsync();
        }
    }
} 