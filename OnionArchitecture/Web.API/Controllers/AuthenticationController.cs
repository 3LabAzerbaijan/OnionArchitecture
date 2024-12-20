﻿using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.Dtos;

namespace Web.API.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IServiceManager _service;

        public AuthenticationController(IServiceManager serviceManager) => _service = serviceManager;

        [HttpPost]
        // [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistration)
        {
            var result = await _service.AuthenticationService.RegisterUser(userForRegistration);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }

                return BadRequest(ModelState);
            }

            return StatusCode(201);
        }

        [HttpPost("login")]
        // [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
        {
            if (!await _service.AuthenticationService.ValidateUser(user))
                return Unauthorized();

            var tokenDto = await _service.AuthenticationService.CreateToken();

            return Ok(tokenDto);
        }

        //[HttpPost("refresh-token")]
        //public async Task<IActionResult> RefreshToken([FromBody] TokenDto token)
        //{
        //    var tokenDto = await _service.AuthenticationService.RefreshToken(token);

        //    return Ok(tokenDto);
        //}

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _service.AuthenticationService.Logout();

            return NoContent();
        }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword(string oldPassword, string newPassword)
        {
            await _service.AuthenticationService.ChangePassword(oldPassword, newPassword);

            return NoContent();
        }
    }
}