using chomer_backend.Models;
using chomer_backend.Models.DTO;
using chomer_backend.Services.HouseService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace chomer_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseController : ControllerBase
    {
        private readonly IHouseService _service;
        public HouseController(IHouseService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<ActionResult<House>> CreateHouse(CreateHouseDTO house)
        {
            var result = await _service.CreateHouse(house);
            return Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult<List<House>>> GetHouses()
        {
            var result = await _service.GetHouses();
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<House>> DeleteHouse(int id)
        {
            var result = await _service.DeleteHouse(id);
            if (result == null)
                return NotFound("Couldn't find the house.");
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<House>> UpdateHouse(int id, House house)
        {
            var result = await _service.UpdateHouse(id, house);
            if (result == null)
                return NotFound("Couldn't find the house.");
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<House>> GetHouseById(int id)
        {
            var result = await _service.GetHouseById(id);
            if (result == null)
                return NotFound("Couldn't find the house.");
            return Ok(result);
        }
    }
}
