using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TS.BLL.Abstractions;
using TS.DAL.Entities;
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
            ICollection<DAL.Entities.Ticket> tickets = new List<DAL.Entities.Ticket>();

            var user = (User)HttpContext.Items["User"];

            tickets = user.Tickets;

            return _mapper.Map<List<TicketResponseDTO>>(tickets);
        }

        [Authorize]
        [HttpGet("{id}")]
        public ActionResult<TicketResponseDTO> GetById(int id)
        {
            var user = (User)HttpContext.Items["User"];

            foreach (var ticket in user.Tickets)
            {
                if (ticket.ID == id)
                    return _mapper.Map<TicketResponseDTO>(ticket);
            }

            return NotFound();
        }

        [Authorize]
        [HttpPost("Create")]
        public ActionResult<TicketResponseDTO> Create([FromBody] TicketResponseDTO ticketData) {
            var user = (User)HttpContext.Items["User"];

            // TODO: make it work

            return Ok();
        }
    }
}
