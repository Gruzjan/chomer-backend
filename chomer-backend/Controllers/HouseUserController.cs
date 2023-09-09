using AutoMapper;
using chomer_backend.Models;
using chomer_backend.Models.DTO;
using chomer_backend.Services.HouseUserService;
using Microsoft.AspNetCore.Mvc;

namespace chomer_backend.Controllers
{
    [Route("api/users/{userId}/houses/{houseId}/members")]
    [ApiController]
    public class HouseUserController : ControllerBase
    {
        private readonly IHouseUserService _service;
        private readonly ILogger<HouseUserController> _logger;
        private readonly IMapper _mapper;
        public HouseUserController(IHouseUserService service, ILogger<HouseUserController> logger, IMapper mapper)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult> CreateHouseUserByEmail(int houseId, string email)
        {
            try
            {
                var user = await _service.CreateHouseUserByEmail(houseId, email);
                if (user == null)
                    return BadRequest("Something went wrong.");
                var result = _mapper.Map<HouseUserDTO>(user);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(CreateHouseUserByEmail)}");
                return StatusCode(500, "Something went wrong. Please try again later.");
            }
        }
        [HttpGet]
        public async Task<ActionResult> GetHouseUsersByHouseId(int houseId)
        {
            try
            {
                var users = await _service.GetHouseUsersByHouseId(houseId);
                if (users == null)
                    return BadRequest("Wrong house id.");
                var result = _mapper.Map<List<HouseUserDTO>>(users);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetHouseUsersByHouseId)}");
                return StatusCode(500, "Something went wrong. Please try again later.");
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetHouseUserById(int id)
        {
            try
            {
                var user = await _service.GetHouseUserById(id, new List<string>() { "House", "User", "AssignedChores", "CreatedChores" });
                if (user == null)
                    return NotFound("Couldn't find the user.");
                var result = _mapper.Map<HouseUserDTO>(user);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetHouseUserById)}");
                return StatusCode(500, "Something went wrong. Please try again later.");
            }
        }
        [HttpPut]
        public async Task<ActionResult> UpdateHouseUser(int id, UpdateHouseUserDTO request)
        {
            try
            {
                var user = _mapper.Map<HouseUser>(request);
                var result = await _service.UpdateHouseUser(id, user);
                if (result == null)
                    return NotFound("Something went wrong.");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(UpdateHouseUser)}");
                return StatusCode(500, "Something went wrong. Please try again later.");
            }
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteHouseUser(int id)
        {
            try
            {
                var user = await _service.DeleteHouseUser(id);
                if (user == null)
                    return NotFound("Couldn't find the user.");
                var result = _mapper.Map<HouseUserDTO>(user);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(DeleteHouseUser)}");
                return StatusCode(500, "Something went wrong. Please try again later.");
            }
        }
    }
}
