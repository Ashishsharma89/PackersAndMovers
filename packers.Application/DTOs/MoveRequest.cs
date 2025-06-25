using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packer.Application.DTOs
{
    public class MoveRequestDto
    {
        public string SourceAddress { get; set; }
        public string DestinationAddress { get; set; }
        public DateTime MoveDate { get; set; }
        public List<string> Items { get; set; }
    }
}
