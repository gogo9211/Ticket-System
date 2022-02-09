using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TS.DTO.Requests
{
    public class CommentRequestDTO
    {
        [Required]
        public int TicketID { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string Content { get; set; }
    }
}
