using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using API.Web.Services;
using API.Core.Dtos;
using System.Collections.Generic;
using API.Core.Entities;
using System.Linq;
using API.Core.Dtos.Auth;
using System.Threading.Tasks;

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

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterDto registerDto) {

            if (!_userService.EmailIsUnique(registerDto.Email))
                return ValidationProblem(nameof(registerDto.Email), "Username is already in use");

            var entry = await _userService.RegisterAsync(
                registerDto.Email,
                registerDto.Password,
                registerDto.Name
            );

            return Ok(_mapper.Map<User, UserDto>(entry.Entity));
        }
    }
}
