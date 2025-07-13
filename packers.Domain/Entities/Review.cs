using System;

namespace packers.Domain.Entities
{
    public enum ReviewTargetType
    {
        Driver,
        Shipment,
        Service
    }

    public class Review
    {
        public Guid ReviewId { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public int TargetId { get; set; }
        public ReviewTargetType TargetType { get; set; }
        public int Rating { get; set; } // 1-5
        public string Comment { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? Sentiment { get; set; } // For future AI analysis
    }
} 