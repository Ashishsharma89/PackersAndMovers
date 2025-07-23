using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Packer.Domain.Entities
{
    public class Tracking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string tracking_id { get; set; }
        [Required]
        public string status { get; set; }
        public DateTime status_date { get; set; } = DateTime.Now;
        [Required]
        public bool is_active { get; set; }
        [Required]
        public bool is_deleted { get; set; }
    }
}
