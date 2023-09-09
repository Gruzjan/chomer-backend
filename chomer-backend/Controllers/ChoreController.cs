using AutoMapper;
using chomer_backend.Models;
using chomer_backend.Models.DTO;
using chomer_backend.Services.ChoreService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace chomer_backend.Controllers
{
    [Route("api/users/{userId}/houses/{houseId}/chores")]
    [ApiController]
    public class ChoreController : ControllerBase
    {
        private readonly IChoreService _service;
        private readonly ILogger<ChoreController> _logger;
        private readonly IMapper _mapper;
        public ChoreController(IChoreService service, ILogger<ChoreController> logger, IMapper mapper)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult> CreateChore(CreateChoreDTO choreDTO)
        {
            try
            {
                var chore = _mapper.Map<Chore>(choreDTO);
                var result = await _service.CreateChore(chore);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(CreateChore)}");
                return StatusCode(500, "Something went wrong. Please try again later.");
            }
        }
        [HttpGet]
        public async Task<ActionResult> GetChores()
        {
            try
            {
                var chores = await _service.GetChores();
                var result = _mapper.Map<List<ChoreDTO>>(chores);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetChores)}");
                return StatusCode(500, "Something went wrong. Please try again later.");
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetChoreById(int id)
        {
            try
            {
                var chore = await _service.GetChoreById(id, new List<string>() { "AssignedTo", "CreatedBy", "House" });
                if (chore == null)
                    return NotFound("Coulnd't find the chore.");
                var result = _mapper.Map<ChoreDTO>(chore);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetChoreById)}");
                return StatusCode(500, "Something went wrong. Please try again later.");
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateChore(int id, UpdateChoreDTO requestDTO)
        {
            try
            {
                var request = _mapper.Map<Chore>(requestDTO);
                var chore = await _service.UpdateChore(id, request);
                if (chore == null)
                    return NotFound("Coulnd't find the chore.");
                return Ok(chore);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(UpdateChore)}");
                return StatusCode(500, "Something went wrong. Please try again later.");
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteChore(int id)
        {
            try
            {
                var chore = await _service.DeleteChore(id);
                if (chore == null)
                    return NotFound("Couldn't find the chore.");
                var result = _mapper.Map<ChoreDTO>(chore);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(DeleteChore)}");
                return StatusCode(500, "Something went wrong. Please try again later.");
            }
        }
    }
}
