using System;

namespace packers.Application.DTOs
{
    public class ShipmentStatusDto
    {
        public int ShipmentId { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime? EstimatedArrival { get; set; }
        public bool DeliveryConfirmed { get; set; }
    }
} 