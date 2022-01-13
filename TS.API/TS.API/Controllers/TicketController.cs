using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TS.BLL.Abstractions;
using TS.DTO.Requests;
using TS.DTO.Responses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public TicketController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        public ICollection<TicketResponseDTO> GetAll()
        {
            return null;
            /*ICollection<DAL.Entities.Ticket> tickets = new List<DAL.Entities.Ticket>();

            var userId = HttpContext.Session.GetInt32("id");

            if (userId == null)
                return _mapper.Map<List<TicketResponseDTO>>(tickets);

            var user = _userService.GetById(userId.Value);

            tickets = user.Tickets;

            return _mapper.Map<List<TicketResponseDTO>>(tickets);*/
        }

        [Authorize]
        [HttpGet("{id}")]
        public ActionResult<TicketResponseDTO> GetById(int id)
        {
            return Ok();
            /*var userId = HttpContext.Session.GetInt32("id");

            if (userId == null)
                return NotFound();

            var user = _userService.GetById(userId.Value);

            foreach (var ticket in user.Tickets)
            {
                if (ticket.ID == id)
                    return _mapper.Map<TicketResponseDTO>(ticket);
            }

            return NotFound();*/
        }
    }
}
