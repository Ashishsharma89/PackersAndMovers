using System;

namespace packers.Application.DTOs
{
    public class CreateDriverWithTruckDto
    {
        public string Name { get; set; }
        public string LicenseNumber { get; set; }
        public string Phone { get; set; }
        public double CurrentLatitude { get; set; }
        public double CurrentLongitude { get; set; }
        public string TruckNumber { get; set; }
    }

    public class UpdateDriverWithTruckDto : CreateDriverWithTruckDto { }
} 