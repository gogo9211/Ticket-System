using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TS.DTO.Responses
{
    public class TicketResponseDTO : BaseResponseDTO
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public ICollection<CommentResponseDTO> Comments { get; set; }
    }
}
