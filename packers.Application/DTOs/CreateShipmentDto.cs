using System;

namespace packers.Application.DTOs
{
    public class CreateShipmentDto
    {
        public int UserId { get; set; }
        public int DriverId { get; set; }
        public DateTime EstimatedArrival { get; set; }
        // Add other relevant fields as needed
    }
} 