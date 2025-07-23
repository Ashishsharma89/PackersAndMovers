using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Packer.Domain.Entities
{
    public class CustomerOrders
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string customer_id { get; set; }
        public string order_id { get; set; }
    }
}
