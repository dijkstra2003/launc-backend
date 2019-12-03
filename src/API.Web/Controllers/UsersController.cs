using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using API.Core.Entities.Auth;
using AutoMapper;
using API.Web.Services;
using API.Core.Dtos;
using System.Collections.Generic;
using API.Core.Entities;
using System.Linq;
using API.Infrastructure.Entities;
using User = API.Core.Entities.User;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]AuthenticateEntity model)
        {
            var user = _userService.Authenticate(model.Username, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(_mapper.Map<UserDto>(user));
        }

        [HttpGet]
        public IActionResult GetAll()
        {            
            var users = _userService.GetAll();
            return Ok(_mapper.Map<List<User>, List<UserDto>>(users.ToList()));
        }
    }
}
