using chomer_backend.Models;
using chomer_backend.Services.RewardService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace chomer_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RewardController : ControllerBase
    {
        private readonly IRewardService _service;
        public RewardController(IRewardService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<List<Reward>>> CreateReward(Reward reward)
        {
            var result = await _service.CreateReward(reward);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<Reward>>> GetRewards()
        {
            var result = await _service.GetRewards();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Reward>>> GetRewards(int id)
        {
            var result = await _service.GetRewardById(id);
            if (result == null)
                return NotFound("Couldn't find the reward.");
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Reward>>> UpdateReward(int id, Reward request)
        {
            var result = await _service.UpdateReward(id, request);
            if (result == null)
                return NotFound("Couldn't find the reward.");
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Reward>>> DeleteReward(int id)
        {
            var result = await _service.DeleteReward(id);
            if (result == null)
                return NotFound("Couldn't find the reward.");
            return Ok(result);
        }
    }
}
