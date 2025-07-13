using System;

namespace packers.Domain.Entities
{
    public class Truck
    {
        public int Id { get; set; }
        public string TruckNumber { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public string Status { get; set; } = "Available";
    }
} 