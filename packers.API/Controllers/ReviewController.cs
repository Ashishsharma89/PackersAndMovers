using Microsoft.AspNetCore.Mvc;
using packers.Application.DTOs;
using packers.Application.Interfaces.Users;
using packers.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace packers.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReview([FromBody] CreateReviewDto dto)
        {
            var review = await _reviewService.AddReviewAsync(dto);
            return Ok(review);
        }

        [HttpGet("target/{targetId}/{targetType}")]
        public async Task<IActionResult> GetReviewsByTarget(int targetId, ReviewTargetType targetType)
        {
            var reviews = await _reviewService.GetReviewsByTargetAsync(targetId, targetType);
            return Ok(reviews);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetReviewsByUser(Guid userId)
        {
            var reviews = await _reviewService.GetReviewsByUserAsync(userId);
            return Ok(reviews);
        }

        [HttpPut("{reviewId}")]
        public async Task<IActionResult> UpdateReview(Guid reviewId, [FromBody] CreateReviewDto dto)
        {
            var result = await _reviewService.UpdateReviewAsync(reviewId, dto);
            if (!result) return NotFound();
            return Ok(new { message = "Review updated." });
        }

        [HttpDelete("{reviewId}")]
        public async Task<IActionResult> DeleteReview(Guid reviewId)
        {
            var result = await _reviewService.DeleteReviewAsync(reviewId);
            if (!result) return NotFound();
            return Ok(new { message = "Review deleted." });
        }
    }
} 