using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TS.DTO.Responses
{
    public class CommentResponseDTO : BaseResponseDTO
    {
        public string Content { get; set; }

        public string CreatorName { get; set; }
    }
}
