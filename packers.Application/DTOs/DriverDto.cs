using System;

namespace packers.Application.DTOs
{
    public class DriverDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double CurrentLatitude { get; set; }
        public double CurrentLongitude { get; set; }
    }
} 