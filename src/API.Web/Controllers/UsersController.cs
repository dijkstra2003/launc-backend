using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using API.Web.Services;
using API.Core.Dtos;
using System.Collections.Generic;
using API.Core.Entities;
using System.Linq;
using API.Core.Dtos.Auth;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private IUserJwtService _userJwtService;
        private IMapper _mapper;

        public UsersController(
            IUserService userService,
            IUserJwtService jwtService,
            IMapper mapper
        ) {
            _userService = userService;
            _userJwtService = jwtService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]AuthenticateDto model)
        {
            var user = _userService.Authenticate(model.Username, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(_userJwtService.CreateJwt(user));
        }

        [HttpGet]
        public IActionResult GetAll()
        {            
            var users = _userService.GetAll();
            return Ok(_mapper.Map<List<User>, List<UserDto>>(users.ToList()));
        }
    }
}
