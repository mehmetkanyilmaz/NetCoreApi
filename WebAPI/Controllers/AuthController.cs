using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);

            if (!userToLogin.Success)
                return BadRequest(userToLogin.Message);

            var accessToken = _authService.CreateAccessToken(userToLogin.Data);
            if (accessToken.Success)
                return Ok(accessToken.Data);

            return BadRequest(accessToken.Message);
        }

        [HttpPost("register")]
        public IActionResult Register(UserForRegistorDto userForRegistorDto)
        {
            var userExists = _authService.UserExist(userForRegistorDto.Email);
            if (!userExists.Success)
                return BadRequest(userExists.Message);

            var registerResult = _authService.Register(userForRegistorDto, userForRegistorDto.Password);
            if (!registerResult.Success)
                return BadRequest(registerResult.Message);

            var accessToken = _authService.CreateAccessToken(registerResult.Data);
            if (accessToken.Success)
                return Ok(accessToken.Data);

            return BadRequest(accessToken.Message);
        }
    }
}
