using System;
using System.Text.Json.Serialization;

namespace packers.Domain.Entities
{
    public class Driver
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LicenseNumber { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Status { get; set; } = "Active";
        public double CurrentLatitude { get; set; }
        public double CurrentLongitude { get; set; }

        public Truck Truck { get; set; }
    }

    public class Truck
    {
        public int Id { get; set; }
        public string TruckNumber { get; set; } = string.Empty;

        public int DriverId { get; set; }
        [JsonIgnore]
        public Driver Driver { get; set; }
    }
}