using System;
using System.Collections.Generic;

namespace packers.Application.DTOs
{
    public class MoveRequestDto
    {
        public DateTime MoveDate { get; set; }
        public TimeSpan? MoveTime { get; set; } // Optional move time
        public List<string> Items { get; set; }
        public string PhoneNumber { get; set; }
        public List<string> ValueAddedServices { get; set; }
        public List<string> SelectedServices { get; set; } // New: Packing, Loading, etc.
        public string SourceAddress { get; set; }
        public string DestinationAddress { get; set; }
    }
} 