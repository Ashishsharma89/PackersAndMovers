using System;

namespace packers.Application.DTOs
{
    public class AssignmentDto
    {
        public Guid Id { get; set; }
        public Guid MoveRequestId { get; set; }
        public Guid DriverId { get; set; }
        public Guid TruckId { get; set; }
        public DateTime PickupTime { get; set; }
        public string Status { get; set; } = string.Empty;
    }

    public class CreateAssignmentDto
    {
        public Guid MoveRequestId { get; set; }
        public Guid DriverId { get; set; }
        public Guid TruckId { get; set; }
        public DateTime PickupTime { get; set; }
    }
} 