using AutoMapper;
using chomer_backend.Models;
using chomer_backend.Models.DTO;
using chomer_backend.Services.RewardService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace chomer_backend.Controllers
{
    [Route("api/users/{userId}/houses/{houseId}/rewards")]
    [ApiController]
    public class RewardController : ControllerBase
    {
        private readonly IRewardService _service;
        private readonly ILogger<RewardController> _logger;
        private readonly IMapper _mapper;
        public RewardController(IRewardService service, ILogger<RewardController> logger, IMapper mapper)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult> CreateReward(CreateRewardDTO rewardDTO)
        {
            try
            {
                var reward = _mapper.Map<Reward>(rewardDTO);
                var result = await _service.CreateReward(reward);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(CreateReward)}");
                return StatusCode(500, "Something went wrong. Please try again later.");
            }
        }
        [HttpGet]
        public async Task<ActionResult> GetRewards()
        {
            try
            {
                var rewards = await _service.GetRewards();
                var result = _mapper.Map<List<RewardDTO>>(rewards);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetRewards)}");
                return StatusCode(500, "Something went wrong. Please try again later.");
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetRewardById(int id)
        {
            try
            {
                var reward = await _service.GetRewardById(id, new List<string> { "House" });
                if (reward == null)
                    return NotFound("Couldn't find the reward.");
                var result = _mapper.Map<RewardDTO>(reward);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetRewardById)}");
                return StatusCode(500, "Something went wrong. Please try again later.");
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateReward(int id, UpdateRewardDTO requestDTO)
        {
            try
            {
                var request = _mapper.Map<Reward>(requestDTO);
                var result = await _service.UpdateReward(id, request);
                if (result == null)
                    return NotFound("Couldn't find the reward.");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(UpdateReward)}");
                return StatusCode(500, "Something went wrong. Please try again later.");
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteReward(int id)
        {
            try
            {
                var reward = await _service.DeleteReward(id);
                if (reward == null)
                    return NotFound("Couldn't find the reward.");
                var result = _mapper.Map<RewardDTO>(reward);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(GetRewards)}");
                return StatusCode(500, "Something went wrong. Please try again later.");
            }
        }
    }
}
