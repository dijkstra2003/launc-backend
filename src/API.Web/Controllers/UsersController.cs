﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using API.Web.Services;
using API.Core.Dtos;
using System.Collections.Generic;
using API.Core.Entities;
using System.Linq;
using API.Core.Dtos.Auth;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace API.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUserJwtService _userJwtService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public UsersController(
            IUserService userService,
            IUserJwtService jwtService,
            IMapper mapper,
            ILogger<UsersController> logger
        ) {
            _userService = userService;
            _userJwtService = jwtService;
            _mapper = mapper;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]AuthenticateDto model)
        {
            User user;

            try {
                user = _userService.Authenticate(model.Email, model.Password);
            } catch (UserAuthenticateException ex) {
                _logger.LogInformation(ex.Message);
                return BadRequest(new { message = "Email or password is incorrect" });
            }
            var JwtToken = _userJwtService.CreateJwt(user);

            return Ok(new {
                Name = user.Name,
                JwtToken = _userJwtService.CreateJwt(user) 
                }
            );
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
