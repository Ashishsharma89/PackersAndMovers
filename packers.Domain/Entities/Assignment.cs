using System;

namespace packers.Domain.Entities
{
    public class Assignment
    {
        public Guid Id { get; set; }
        public Guid MoveRequestId { get; set; }
        public Guid DriverId { get; set; }
        public Guid TruckId { get; set; }
        public DateTime PickupTime { get; set; }
        public string Status { get; set; } = "Assigned";
    }
} 