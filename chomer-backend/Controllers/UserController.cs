using chomer_backend.Data;
using chomer_backend.Models;
using chomer_backend.Services.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace chomer_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<ActionResult<List<User>>> CreateUser(User user)
        {
            var result = await _service.CreateUser(user);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var result = await _service.GetUserById(id);
            if (result == null) return NotFound("Couldn't find the user.");
            return Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            var result = await _service.GetUsers();
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<User>>> UpdateUser(int id, User request)
        {
            var result = await _service.UpdateUser(id, request);
            if (result == null) return BadRequest("Something went wrong");
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<User>>> DeleteUser(int id)
        {
            var result = await _service.DeleteUser(id);
            if (result == null) return NotFound("Couldn't find the user.");
            return Ok(result);
        }
    }
}
