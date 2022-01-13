using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TS.DTO.Requests {
    public class CreateTicketRequestDTO {
        public string Title { get; set; }

        public string Description { get; set; }
    }
}
