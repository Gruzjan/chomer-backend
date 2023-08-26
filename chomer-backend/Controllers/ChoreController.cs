﻿using AutoMapper;
using chomer_backend.Models;
using chomer_backend.Models.DTO;
using chomer_backend.Services.ChoreService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace chomer_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChoreController : ControllerBase
    {
        private readonly IChoreService _service;
        private readonly IMapper _mapper;
        public ChoreController(IChoreService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult> CreateChore(CreateChoreDTO choreDTO)
        {
            var chore = _mapper.Map<Chore>(choreDTO);
            var result = await _service.CreateChore(chore);
            return Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult> GetChores()
        {
            var chores = await _service.GetChores();
            var result = _mapper.Map<List<ChoreDTO>>(chores);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetChoreById(int id)
        {
            var chore = await _service.GetChoreById(id);
            if (chore == null)
                return NotFound("Coulnd't find the chore.");
            var result = _mapper.Map<ChoreDTO>(chore);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateChore(int id, UpdateChoreDTO requestDTO)
        {
            var request = _mapper.Map<Chore>(requestDTO);
            var chore = await _service.UpdateChore(id, request);
            if (chore == null)
                return NotFound("Coulnd't find the chore.");

            return Ok(chore);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteChore(int id)
        {
            var chore = await _service.DeleteChore(id);
            if (chore == null)
                return NotFound("Couldn't find the chore.");
            var result = _mapper.Map<ChoreDTO>(chore);
            return Ok(result);
        }
    }
}
