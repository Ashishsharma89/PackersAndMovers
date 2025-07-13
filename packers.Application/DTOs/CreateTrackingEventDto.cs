using System;

namespace packers.Application.DTOs
{
    public class CreateTrackingEventDto
    {
        public Guid ShipmentId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Status { get; set; } = string.Empty;
    }
} 