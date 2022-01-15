using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TS.DTO.Requests
{
    public class TicketRequestDTO
    {
        [Required]
        [MinLength(3)]
        [MaxLength(15)]
        public string Title { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Description { get; set; }
    }
}
