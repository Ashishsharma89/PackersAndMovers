using System;

namespace packers.Domain.Entities
{
    public class Assignment
    {
        public int Id { get; set; }
        public int MoveRequestId { get; set; }
        public int DriverId { get; set; }
        public int TruckId { get; set; }
        public DateTime PickupTime { get; set; }
        public string Status { get; set; } = "Assigned";
    }
} 