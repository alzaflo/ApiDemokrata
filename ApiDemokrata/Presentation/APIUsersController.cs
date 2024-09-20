using ApiDemokrata.Application;
using ApiDemokrata.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ApiDemokrata.Presentation
{
    [ApiController]
    [Route("[controller]")]
    public class APIUsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public APIUsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] User request)
        {
            var result = await _userService.CreateUserAsync(request);
            return CreatedAtAction(nameof(GetUserById), new { id = result.Id }, result);
        }

        [HttpGet]
        [Route("GetUserById")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            return user != null ? Ok(user) : NotFound();
        }

        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User request)
        {
            await _userService.UpdateUserAsync(id, request);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUserAsync(id);
            return Ok();
        }

        [HttpGet]
        [Route("SearchUsers")]
        public async Task<IActionResult> SearchUsers([FromQuery] string firstName, [FromQuery] string lastName, [FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            var users = await _userService.SearchUsersAsync(firstName, lastName, pageNumber, pageSize);
            return Ok(users);
        }
    }
}
