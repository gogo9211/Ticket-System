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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] UserRequestDTO registrationData)
        {
            if (_userService.UserExist(registrationData.Username))
                return BadRequest(new { status = 0, message = "Username Already Exist" });

            var user = _userService.Create(registrationData.Username, registrationData.Password);

            if (user != null)
                return Ok(new { status = 1, message = "Successfully Registered" });

            return BadRequest(new { status = 0, message = "Error" });
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] UserRequestDTO loginData)
        {
            string token = _userService.Login(loginData.Username, loginData.Password);

            if (string.IsNullOrEmpty(token))
                return BadRequest(new { status = 0, message = "Username or Password is Incorrect" });

            return Ok(new { status = 1, username = loginData.Username, token = token });
        }

        // GET: api/<UserController>
        [HttpGet]
        public ICollection<UserResponseDTO> GetAll()
        {
            var userResponse = _userService.GetAll();

            return _mapper.Map<List<UserResponseDTO>>(userResponse);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult Disable(int id)
        {
            if (_userService.Disable(id))
                return Ok(new { status = 1, message = "Successfully Disabled User" });

            return BadRequest(new { status = 0, message = "Can't Disable This User" });
        }
    }
}
