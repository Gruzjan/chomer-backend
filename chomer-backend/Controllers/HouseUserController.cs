using AutoMapper;
using chomer_backend.Models;
using chomer_backend.Models.DTO;
using chomer_backend.Services.HouseUserService;
using Microsoft.AspNetCore.Mvc;

namespace chomer_backend.Controllers
{
    [Route("api/House/HouseUsers")]
    [ApiController]
    public class HouseUserController : ControllerBase
    {
        private readonly IHouseUserService _service;
        private readonly IMapper _mapper;
        public HouseUserController(IHouseUserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult> CreateHouseUserByEmail(int houseId, string email)
        {
            var user = await _service.CreateHouseUserByEmail(houseId, email);
            if (user == null)
                return BadRequest("Something went wrong.");
            var result = _mapper.Map<HouseUserDTO>(user);
            return Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult> GetHouseUsersByHouseId(int houseId)
        {
            var users = await _service.GetHouseUsersByHouseId(houseId);
            if (users == null)
                return BadRequest("Wrong house id.");
            var result = _mapper.Map<List<HouseUserDTO>>(users);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetHouseUserById(int id)
        {
            //var result = await _service.GetHouseUserById(id, new List<string>() {"House"});
            var user = await _service.GetHouseUserById(id);
            if (user == null)
                return NotFound("Couldn't find the user.");
            var result = _mapper.Map<HouseUserDTO>(user);
            return Ok(result);
        }
        [HttpPut]
        public async Task<ActionResult> UpdateHouseUser(int id, UpdateHouseUserDTO request)
        {
            var user = _mapper.Map<HouseUser>(request);
            var result = await _service.UpdateHouseUser(id, user);
            if (result == null)
                return NotFound("Something went wrong.");
            return Ok(result);
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteHouseUser(int id)
        {
            var user = await _service.DeleteHouseUser(id);
            if (user == null)
                return NotFound("Couldn't find the user.");
            var result = _mapper.Map<HouseUserDTO>(user);
            return Ok(result);
        }
    }
}
