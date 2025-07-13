using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using packers.Application.Interfaces.Repository;
using packers.Domain.Entities;
using packers.Infrastructure.Data;

namespace packers.Infrastructure.Repositories.Users
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ApplicationDbContext _context;
        public ReviewRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Review> AddAsync(Review review)
        {
            await _context.AddAsync(review);
            await _context.SaveChangesAsync();
            return review;
        }

        public async Task<IEnumerable<Review>> GetByTargetAsync(int targetId, ReviewTargetType targetType)
        {
            return await _context.Set<Review>().Where(r => r.TargetId == targetId && r.TargetType == targetType).ToListAsync();
        }

        public async Task<IEnumerable<Review>> GetByUserAsync(Guid userId)
        {
            return await _context.Set<Review>().Where(r => r.UserId == userId).ToListAsync();
        }

        public async Task<Review?> GetByIdAsync(Guid reviewId)
        {
            return await _context.Set<Review>().FirstOrDefaultAsync(r => r.ReviewId == reviewId);
        }

        public async Task<bool> DeleteAsync(Guid reviewId)
        {
            var review = await GetByIdAsync(reviewId);
            if (review == null) return false;
            _context.Remove(review);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(Review review)
        {
            _context.Update(review);
            await _context.SaveChangesAsync();
            return true;
        }
    }
} 