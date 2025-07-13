using System.Collections.Generic;
using System.Threading.Tasks;
using packers.Domain.Entities;

namespace packers.Application.Interfaces.Repository
{
    public interface IReviewRepository
    {
        Task<Review> AddAsync(Review review);
        Task<IEnumerable<Review>> GetByTargetAsync(int targetId, ReviewTargetType targetType);
        Task<IEnumerable<Review>> GetByUserAsync(Guid userId);
        Task<Review?> GetByIdAsync(Guid reviewId);
        Task<bool> DeleteAsync(Guid reviewId);
        Task<bool> UpdateAsync(Review review);
    }
} 