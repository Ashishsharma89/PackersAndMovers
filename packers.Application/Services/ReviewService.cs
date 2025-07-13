using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using packers.Application.DTOs;
using packers.Application.Interfaces.Repository;
using packers.Application.Interfaces.Users;
using packers.Domain.Entities;

namespace packers.Application.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<ReviewDto> AddReviewAsync(CreateReviewDto dto)
        {
            var review = new Review
            {
                ReviewId = GenerateNewReviewId(), // Replace int.newInt() with a proper method to generate a new ID
                UserId = dto.UserId,
                TargetId = dto.TargetId,
                TargetType = dto.TargetType,
                Rating = dto.Rating,
                Comment = dto.Comment,
                CreatedAt = System.DateTime.UtcNow
            };
            var result = await _reviewRepository.AddAsync(review);
            return ToDto(result);
        }

        // Add a private method to generate a new ReviewId
        private int GenerateNewReviewId()
        {
            // Example implementation: Generate a random positive integer
            return new Random().Next(1, int.MaxValue);
        }

        public async Task<IEnumerable<ReviewDto>> GetReviewsByTargetAsync(int targetId, ReviewTargetType targetType)
        {
            var reviews = await _reviewRepository.GetByTargetAsync(targetId, targetType);
            return reviews.Select(ToDto);
        }

        public async Task<IEnumerable<ReviewDto>> GetReviewsByUserAsync(int userId)
        {
            var reviews = await _reviewRepository.GetByUserAsync(userId);
            return reviews.Select(ToDto);
        }

        public async Task<bool> DeleteReviewAsync(int reviewId)
        {
            return await _reviewRepository.DeleteAsync(reviewId);
        }

        public async Task<bool> UpdateReviewAsync(int reviewId, CreateReviewDto dto)
        {
            var review = await _reviewRepository.GetByIdAsync(reviewId);
            if (review == null) return false;
            review.Rating = dto.Rating;
            review.Comment = dto.Comment;
            review.TargetId = dto.TargetId;
            review.TargetType = dto.TargetType;
            await _reviewRepository.UpdateAsync(review);
            return true;
        }

        private ReviewDto ToDto(Review review)
        {
            return new ReviewDto
            {
                ReviewId = review.ReviewId,
                UserId = review.UserId,
                UserName = review.UserName,
                TargetId = review.TargetId,
                TargetType = review.TargetType,
                Rating = review.Rating,
                Comment = review.Comment,
                CreatedAt = review.CreatedAt,
                Sentiment = review.Sentiment
            };
        }
    }
} 