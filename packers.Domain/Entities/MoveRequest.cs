using System;

namespace packers.Domain.Entities
{
    public class MoveRequest
    {
        public int Id { get; set; }
        public string SourceAddress { get; set; } = string.Empty;
        public string DestinationAddress { get; set; } = string.Empty;
        public DateTime MoveDate { get; set; }
        public TimeSpan? MoveTime { get; set; }
        public string Items { get; set; } = string.Empty;
        public string Status { get; set; } = "Pending";
        public decimal EstimatedPrice { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string? ValueAddedServices { get; set; }
        public string? SelectedServices { get; set; }
        public int UserId { get; set; }
    }
} 