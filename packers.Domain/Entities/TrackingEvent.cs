using Packer.Domain.Entities;
using System;

namespace packers.Domain.Entities
{
    public class TrackingEvent
    {
        public int Id { get; set; }
        public int ShipmentId { get; set; }
        public DateTime Timestamp { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public TrackingStatus Status { get; set; }
    }
}