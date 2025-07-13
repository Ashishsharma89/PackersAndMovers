using System;

namespace packers.Application.DTOs
{
    public class CreateShipmentDto
    {
        public Guid UserId { get; set; }
        public Guid DriverId { get; set; }
        public DateTime EstimatedArrival { get; set; }
        // Add other relevant fields as needed
    }
} 