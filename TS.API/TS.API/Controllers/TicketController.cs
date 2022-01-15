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
        private readonly ITicketService _ticketService;
        private readonly IMapper _mapper;

        public TicketController(IMapper mapper, ITicketService ticketService)
        {
            _mapper = mapper;
            _ticketService = ticketService;
        }

        [Authorize]
        [HttpGet]
        public ICollection<TicketResponseDTO> GetAll()
        {
            ICollection<Ticket> tickets;

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
        public IActionResult Create([FromBody] TicketRequestDTO ticketData)
        {
            var user = (User)HttpContext.Items["User"];

            var ticket = _ticketService.Create(user, ticketData.Title, ticketData.Description);

            if (ticket != null)
                return Ok(new { status = 1, message = "Successfully Created Ticket" });

            return BadRequest(new { status = 0, message = "Error" });
        }
    }
}
