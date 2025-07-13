using System;

namespace packers.Application.DTOs
{
    public class AssignmentDto
    {
        public int Id { get; set; }
        public int MoveRequestId { get; set; }
        public int DriverId { get; set; }
        public int TruckId { get; set; }
        public DateTime PickupTime { get; set; }
        public string Status { get; set; } = string.Empty;
    }

    public class CreateAssignmentDto
    {
        public int MoveRequestId { get; set; }
        public int DriverId { get; set; }
        public int TruckId { get; set; }
        public DateTime PickupTime { get; set; }
    }
} 