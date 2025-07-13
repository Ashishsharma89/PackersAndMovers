using System.Collections.Generic;
using System.Threading.Tasks;
using packers.Application.DTOs;
using packers.Domain.Entities;

namespace packers.Application.Interfaces.Users
{
    public interface IReviewService
    {
        Task<ReviewDto> AddReviewAsync(CreateReviewDto dto);
        Task<IEnumerable<ReviewDto>> GetReviewsByTargetAsync(int targetId, ReviewTargetType targetType);
        Task<IEnumerable<ReviewDto>> GetReviewsByUserAsync(int userId);
        Task<bool> DeleteReviewAsync(int reviewId);
        Task<bool> UpdateReviewAsync(int reviewId, CreateReviewDto dto);
    }
} 