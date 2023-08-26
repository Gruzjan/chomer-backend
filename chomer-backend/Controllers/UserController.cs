using AutoMapper;
using chomer_backend.Data;
using chomer_backend.Models;
using chomer_backend.Models.DTO;
using chomer_backend.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace chomer_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly ILogger<UserController> _logger;
        private readonly IMapper _mapper;
        public UserController(IUserService service, ILogger<UserController> logger, IMapper mapper)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser(CreateUserDTO userDTO)
        {
            try
            {
                var user = _mapper.Map<User>(userDTO);
                var result = await _service.CreateUser(user);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(CreateUser)}");
                return StatusCode(500, "Something went wrong. Please try again later.");
            }
        }
        [HttpGet]
        public async Task<ActionResult> GetUsers()
        {
            try
            {
                var users = await _service.GetUsers();
                var result = _mapper.Map<List<UserDTO>>(users);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetUsers)}");
                return StatusCode(500, "Something went wrong. Please try again later.");
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetUserById(int id)
        {
            try
            {
                var user = await _service.GetUserById(id);
                if (user == null) return NotFound("Couldn't find the user.");
                var result = _mapper.Map<UserDTO>(user);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetUserById)}");
                return StatusCode(500, "Something went wrong. Please try again later.");
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int id, UpdateUserDTO requestDTO)
        {
            try
            {
                var request = _mapper.Map<User>(requestDTO);
                var result = await _service.UpdateUser(id, request);
                if (result == null) return BadRequest("Something went wrong");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(UpdateUser)}");
                return StatusCode(500, "Something went wrong. Please try again later.");
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            try
            {
                var user = await _service.DeleteUser(id);
                if (user == null)
                    return NotFound("Couldn't find the user.");
                var result = _mapper.Map<UserDTO>(user);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(DeleteUser)}");
                return StatusCode(500, "Something went wrong. Please try again later.");
            }
        }
    }
}
