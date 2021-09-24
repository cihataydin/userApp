using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UserApi.Services;
using UserApi.DTO.Response;
using UserApi.DTO.Request;

namespace UserApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IList<UserResponseDto>> GetUsers()
        {
            return await _userService.GetUsersAsync();
        }

        [HttpGet]
        public async Task<IActionResult> GetUserById([FromQuery] int id)
        {
            var result =  await _userService.GetUserByIdAsync(id);

            if(result is null)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequestDto createUserRequestDto)
        {
            
            var result = await _userService.CreateUserAsync(createUserRequestDto);

            if(result is null)
            {
                return BadRequest(result);
            }

            return CreatedAtAction(nameof(GetUserById), new { id = result.Id }, result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequestDto updateUserRequestDto)
        {
            var result = await _userService.UpdateUserAsync(updateUserRequestDto);

            if(result is null)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userService.DeleteUserAsync(id);

            if(result is null)
            {
                return BadRequest(result);
            }

            return Ok();        
        }
    }
}
