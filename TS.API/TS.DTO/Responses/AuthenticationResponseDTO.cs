using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.DAL.Entities;

namespace TS.DTO.Responses {
    public class AuthenticationResponseDTO : BaseResponseDTO {
        public string Username { get; set; }
        public string Token { get; set; }

        public AuthenticationResponseDTO(User user, string token) {
            ID = user.ID;
            Username = user.Username;
            Token = token;
        }
    }
}
