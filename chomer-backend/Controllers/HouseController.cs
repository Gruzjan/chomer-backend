using AutoMapper;
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
        private readonly IMapper _mapper;
        public HouseController(IHouseService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult> CreateHouse(CreateHouseDTO house)
        {
            var result = await _service.CreateHouse(house);
            return Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult> GetHouses()
        {
            var houses = await _service.GetHouses();
            var result = _mapper.Map<List<HouseDTO>>(houses);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetHouseById(int id)
        {
            var house = await _service.GetHouseById(id);
            if (house == null)
                return NotFound("Couldn't find the house.");
            var result = _mapper.Map<HouseDTO>(house);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateHouse(int id, UpdateHouseDTO houseDTO)
        {
            var house = _mapper.Map<House>(houseDTO);
            var result = await _service.UpdateHouse(id, house);
            if (result == null)
                return NotFound("Couldn't find the house.");
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHouse(int id)
        {
            var house = await _service.DeleteHouse(id);
            if (house == null)
                return NotFound("Couldn't find the house.");
            var result = _mapper.Map<HouseDTO>(house);
            return Ok(result);
        }
    }
}
