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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost("Register"), AllowAnonymous]
        public IActionResult Register([FromBody] UserRequestDTO registrationData)
        {
            var user = _userService.Create(registrationData.Username, registrationData.Password); //we need sanity checks in create later

            if (user != null)
                return Ok(new { status = 1, message = "Successfully Registered" });

            return BadRequest(new { status = 0, message = "Error" });
        }

        [HttpPost("Login"), AllowAnonymous]
        public IActionResult Login([FromBody] UserRequestDTO loginData)
        {
            if (HttpContext.Session.GetInt32("id") != null)
                return BadRequest(new { message = "Already Logged In" });

            var id = _userService.Login(loginData.Username, loginData.Password);

            if (id != -1)
            {
                HttpContext.Session.SetInt32("id", id);

                return Ok(new { status = 1, message = "Successfully Logged In" });
            }

            return BadRequest(new { status = 0, message = "Username or password is incorrect" });
        }

        // GET: api/<UserController>
        [HttpGet]
        public ICollection<UserResponseDTO> GetAll()
        {
            var userResponse = _userService.GetAll();

            return _mapper.Map<List<UserResponseDTO>>(userResponse);
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public ActionResult<UserResponseDTO> Get(int id)
        {
            var userResponse = _userService.GetById(id);

            if (userResponse == null)
                return NotFound();

            return Ok(_mapper.Map<UserResponseDTO>(userResponse));
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _userService.Delete(id);
        }

        // PUT api/<UserController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}
    }
}
