using System;

namespace packers.Application.DTOs
{
    public class TruckDto
    {
        public Guid Id { get; set; }
        public string TruckNumber { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public string Status { get; set; } = string.Empty;
    }

    public class CreateTruckDto
    {
        public string TruckNumber { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Capacity { get; set; }
    }
} 