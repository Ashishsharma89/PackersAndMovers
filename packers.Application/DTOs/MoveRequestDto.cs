using System;
using System.Collections.Generic;

namespace packers.Application.DTOs
{
    public class MoveRequestDto
    {
        public string SourceAddress { get; set; } = string.Empty;
        public string DestinationAddress { get; set; } = string.Empty;
        public DateTime MoveDate { get; set; }
        public TimeSpan? MoveTime { get; set; }
        public List<string>? Items { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public List<string>? ValueAddedServices { get; set; }
        public List<string>? SelectedServices { get; set; }
        public string? SpecialInstructions { get; set; }
        public string? UrgencyLevel { get; set; }
        public decimal EstimatedPrice { get; set; }
        public string Status { get; set; } = "Pending";
    }
} 