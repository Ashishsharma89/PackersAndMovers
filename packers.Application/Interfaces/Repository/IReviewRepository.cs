using System.Collections.Generic;
using System.Threading.Tasks;
using packers.Domain.Entities;

namespace packers.Application.Interfaces.Repository
{
    public interface IReviewRepository
    {
        Task<Review> AddAsync(Review review);
        Task<IEnumerable<Review>> GetByTargetAsync(int targetId, ReviewTargetType targetType);
        Task<IEnumerable<Review>> GetByUserAsync(int userId);
        Task<Review?> GetByIdAsync(int reviewId);
        Task<bool> DeleteAsync(int reviewId);
        Task<bool> UpdateAsync(Review review);
    }
} 