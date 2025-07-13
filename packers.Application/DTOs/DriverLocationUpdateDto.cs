using System;

namespace packers.Application.DTOs
{
    public class DriverLocationUpdateDto
    {
        public int DriverId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
} 