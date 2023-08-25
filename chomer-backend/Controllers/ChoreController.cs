using chomer_backend.Models;
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
        public ChoreController(IChoreService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<ActionResult<Chore>> CreateChore(Chore chore)
        {
            var result = await _service.CreateChore(chore);
            return Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult<List<Chore>>> GetChores()
        {
            var result = await _service.GetChores();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Chore>> GetChoreById(int id)
        {
            var result = await _service.GetChoreById(id);
            if (result == null)
                return NotFound("Coulnd't find the chore.");
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Chore>> UpdateChore(int id, Chore request)
        {
            var result = await _service.UpdateChore(id, request);
            if (result == null)
                return NotFound("Coulnd't find the chore.");
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Chore?>> DeleteChore(int id)
        {
            var result = await _service.DeleteChore(id);
            if (result == null)
                return NotFound("Couldn't find the chore.");
            return Ok(result);
        }
    }
}
