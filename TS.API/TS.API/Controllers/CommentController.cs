using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TS.BLL.Abstractions;
using TS.DAL.Entities;
using TS.DTO.Requests;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly ITicketService _TicketService;
        private readonly IMapper _mapper;

        public CommentController(IMapper mapper, ICommentService commentService, ITicketService TicketService)
        {
            _mapper = mapper;
            _commentService = commentService;
            _TicketService = TicketService;
        }

        [Authorize]
        [HttpPost("Create")]
        public IActionResult Create([FromBody] CommentRequestDTO commentData)
        {
            var user = (User)HttpContext.Items["User"];

            var ticket = _TicketService.GetById(commentData.TicketID);

            if (ticket == null || ticket.User.ID != user.ID)
                return BadRequest(new { status = 0, message = "Invalid Ticket ID" });

            var comment = _commentService.Create(ticket, user, commentData.Content);

            if (comment != null)
                return Ok(new { status = 1, message = "Successfully Created Comment" });

            return BadRequest(new { status = 0, message = "Error" });
        }
    }
}
