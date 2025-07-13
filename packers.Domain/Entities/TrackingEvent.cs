using System;

namespace packers.Domain.Entities
{
    public enum TrackingStatus
    {
        PickedUp,
        InTransit,
        Arrived,
        Delivered
    }

    public class TrackingEvent
    {
        public Guid Id { get; set; }
        public Guid ShipmentId { get; set; }
        public DateTime Timestamp { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public TrackingStatus Status { get; set; }
    }
} 