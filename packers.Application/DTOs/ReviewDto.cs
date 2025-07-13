using System;
using packers.Domain.Entities;

namespace packers.Application.DTOs
{
    public class ReviewDto
    {
        public int ReviewId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public int TargetId { get; set; }
        public ReviewTargetType TargetType { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public string? Sentiment { get; set; }
    }
} 