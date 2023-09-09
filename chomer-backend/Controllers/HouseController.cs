using AutoMapper;
using chomer_backend.Models;
using chomer_backend.Models.DTO;
using chomer_backend.Services.HouseService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace chomer_backend.Controllers
{
    [Route("api/users/{userId}/houses")]
    [ApiController]
    public class HouseController : ControllerBase
    {
        private readonly IHouseService _service;
        private readonly ILogger<HouseController> _logger;
        private readonly IMapper _mapper;
        public HouseController(IHouseService service, ILogger<HouseController> logger, IMapper mapper)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult> CreateHouse(CreateHouseDTO houseDTO)
        {
            try
            {
                var house = _mapper.Map<House>(houseDTO);
                var result = await _service.CreateHouse(house);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(CreateHouse)}");
                return StatusCode(500, "Something went wrong. Please try again later.");
            }
        }
        [HttpGet]
        public async Task<ActionResult> GetHouses()
        {
            try
            {
                var houses = await _service.GetHouses();
                var result = _mapper.Map<List<HouseDTO>>(houses);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetHouses)}");
                return StatusCode(500, "Something went wrong. Please try again later.");
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetHouseById(int id)
        {
            try
            {
                var house = await _service.GetHouseById(id, new List<string>() { "Owner", "HouseUsers", "Chores", "Rewards"});
                if (house == null)
                    return NotFound("Couldn't find the house.");
                var result = _mapper.Map<HouseDTO>(house);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetHouseById)}");
                return StatusCode(500, "Something went wrong. Please try again later.");
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateHouse(int id, UpdateHouseDTO houseDTO)
        {
            try
            {
                var house = _mapper.Map<House>(houseDTO);
                var result = await _service.UpdateHouse(id, house);
                if (result == null)
                    return NotFound("Couldn't find the house.");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(UpdateHouse)}");
                return StatusCode(500, "Something went wrong. Please try again later.");
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHouse(int id)
        {
            try
            {
                var house = await _service.DeleteHouse(id);
                if (house == null)
                    return NotFound("Couldn't find the house.");
                var result = _mapper.Map<HouseDTO>(house);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(DeleteHouse)}");
                return StatusCode(500, "Something went wrong. Please try again later.");
            }
        }
    }
}
