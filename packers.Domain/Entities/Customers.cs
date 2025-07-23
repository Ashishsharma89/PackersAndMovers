using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Packer.Domain.Entities
{
    public class Customers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string customer_id { get; set; }
        [Required]
        public string customer_name { get; set; }
        [Required]
        public long phone { get; set; }
        [Required]
        public string email { get; set; }
        public DateTime created_date { get; set; }
        public bool is_active { get; set; } = true;
        public bool is_deleted { get; set; } = false;
    }
}
