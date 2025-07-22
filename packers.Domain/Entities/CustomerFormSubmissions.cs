using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Packer.Domain.Entities
{
    public class CustomerFormSubmissions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public DateTime form_submission_date { get; set; } = DateTime.Now;
        [Required]
        public string customer_name { get; set; }
        [Required]
        public string phone { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string origin_location_name { get; set; }
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
        [Required]
        public string delivery_status { get; set; }
    }
}
