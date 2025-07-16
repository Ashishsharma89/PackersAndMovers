using System;

namespace packers.Application.DTOs
{
    public class DriverDto
    {
        public string Name { get; set; } = string.Empty;
        public string LicenseNumber { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Status { get; set; } = "Active"; //
        public double CurrentLatitude { get; set; }
        public double CurrentLongitude { get; set; }
    }
} 