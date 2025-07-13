using System;

namespace packers.Domain.Entities
{
    public enum ShipmentStatus
    {
        Pending,
        InTransit,
        Delivered,
        Cancelled
    }

    public class Shipment
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid DriverId { get; set; }
        public ShipmentStatus Status { get; set; }
        public DateTime EstimatedArrival { get; set; }
        public bool DeliveryConfirmed { get; set; }
    }
} 