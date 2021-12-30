using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.DAL.Entities;

namespace TS.DTO.Responses
{
    public class UserResponseDTO : BaseResponseDTO
    {
        public string Username { get; set; }

        public ICollection<TicketResponseDTO> Tickets { get; set; }
    }
}
