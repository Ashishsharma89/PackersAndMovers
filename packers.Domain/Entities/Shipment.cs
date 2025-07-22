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
        public int Id { get; set; }
        public int UserId { get; set; }
        public int DriverId { get; set; }
        public ShipmentStatus Status { get; set; }
        public DateTime EstimatedArrival { get; set; }
        public bool DeliveryConfirmed { get; set; }
    }
} 