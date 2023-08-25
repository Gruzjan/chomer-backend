﻿using AutoMapper;
using chomer_backend.Models;
using chomer_backend.Models.DTO;
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
        private readonly ILogger<RewardController> _logger;
        private readonly IMapper _mapper;
        public RewardController(IRewardService service, ILogger<RewardController> logger, IMapper mapper)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<Reward>> CreateReward(Reward reward)
        {
            var result = await _service.CreateReward(reward);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<Reward>>> GetRewards()
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
        public async Task<ActionResult<Reward>> GetRewardById(int id)
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
        public async Task<ActionResult<Reward>> UpdateReward(int id, Reward request)
        {
            var result = await _service.UpdateReward(id, request);
            if (result == null)
                return NotFound("Couldn't find the reward.");
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Reward>> DeleteReward(int id)
        {
            var result = await _service.DeleteReward(id);
            if (result == null)
                return NotFound("Couldn't find the reward.");
            return Ok(result);
        }
    }
}
