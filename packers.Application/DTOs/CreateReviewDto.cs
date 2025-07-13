using System;
using packers.Domain.Entities;

namespace packers.Application.DTOs
{
    public class CreateReviewDto
    {
        public Guid UserId { get; set; }
        public int TargetId { get; set; }
        public ReviewTargetType TargetType { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; } = string.Empty;
    }
} 