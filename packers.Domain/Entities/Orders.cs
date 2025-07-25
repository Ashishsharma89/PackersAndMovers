using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Packer.Domain.Entities
{
    public class Orders
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string order_id { get; set; }
        [Required]
        public string origin_location_lat { get; set; }
        [Required]
        public string origin_location_long { get; set; }
        [Required]
        public string destination_location_name { get; set; }
        [Required]
        public string destination_location_lat { get; set; }
        [Required]
        public string destination_location_long { get; set; }
        [Required]
        public decimal distance_in_km { get; set; }
        [Required]
        public string items_json { get; set; }
        public bool urgency { get; set; } = false;
        [Required]
        public decimal estimated_price { get; set; }
        public DateTime order_date { get; set; } = DateTime.Now;
        public DateTime delivery_date { get; set; }

        // New properties for driver assignment
        public int? DriverId { get; set; } // Nullable, as order may not have a driver assigned
        public string DriverAssignmentStatus { get; set; } = "NotAssigned"; // e.g., NotAssigned, Assigned, Away, NotAvailable
    }
}
