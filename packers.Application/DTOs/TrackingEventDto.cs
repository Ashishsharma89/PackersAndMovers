using System;

namespace packers.Application.DTOs
{
    public class TrackingEventDto
    {
        public int Id { get; set; }
        public int ShipmentId { get; set; }
        public DateTime Timestamp { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Status { get; set; } = string.Empty;
    }
} 