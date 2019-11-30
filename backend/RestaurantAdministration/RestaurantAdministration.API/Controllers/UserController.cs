using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantAdministration.Application.Dtos;
using RestaurantAdministration.Application.Interfaces;

namespace RestaurantAdministration.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserAppService _service;

        public UserController(IUserAppService service)
        {
            this._service = service;
        }

        [HttpPost("signup")]
        public async Task<ActionResult> CreateUser([FromBody]RegisterUserDto user)
        {
            var createdUser = await _service.Register(user);
            if (!createdUser.Succeeded)
            {
                return BadRequest(createdUser.Errors.Select(e => e.Description));
            }
            else
            {
                return Ok();
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody]LoginUserDto user)
        {
            var loginToken = await _service.Login(user);
            if (loginToken != null)
            {
                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(loginToken) });
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            return Ok(await _service.GetUsersAsync());
        }

        [HttpDelete("{userId}")]
        public async Task<ActionResult> DeleteUser(int userId)
        {
            try
            {
                await _service.RemoveUserAsync(userId);
                return Ok();
            }
            catch (Exception e)
            {
                return Conflict(e.Message);
            }
        }
    }
}