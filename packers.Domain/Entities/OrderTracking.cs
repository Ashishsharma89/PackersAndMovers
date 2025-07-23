using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Packer.Domain.Entities
{
    public class OrderTracking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        public string order_id { get; set; }
        [Required]
        public string tracking_id { get; set; }
        [Required]
        public string status { get; set; }
        [Required]
        public DateTime status_date { get; set; } = DateTime.Now;
    }
}
