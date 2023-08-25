using chomer_backend.Models;
using chomer_backend.Services.HouseUserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace chomer_backend.Controllers
{
    [Route("api/House/HouseUsers")]
    [ApiController]
    public class HouseUserController : ControllerBase
    {
        private readonly IHouseUserService _service;
        public HouseUserController(IHouseUserService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<ActionResult<HouseUser>> CreateHouseUserByEmail(int houseId, string email)
        {
            var result = await _service.CreateHouseUserByEmail(houseId, email);
            if (result == null)
                return BadRequest("Something went wrong");
            return Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult<List<HouseUser>>> GetHouseUsersByHouseId(int houseId)
        {
            var result = await _service.GetHouseUsersByHouseId(houseId);
            if (result == null)
                return BadRequest("Bad house id.");
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<HouseUser>> GetHouseUserById(int id)
        {
            //var result = await _service.GetHouseUserById(id, new List<string>() {"House"});
            var result = await _service.GetHouseUserById(id);
            if (result == null)
                return NotFound("Couldn't find the user.");
            return Ok(result);
        }
        [HttpPut]
        public async Task<ActionResult<HouseUser>> UpdateHouseUser(int id, HouseUser request)
        {
            var result = await _service.UpdateHouseUser(id, request);
            if (result == null)
                return NotFound("Something went wrong.");
            return Ok(result);
        }
        [HttpDelete]
        public async Task<ActionResult<HouseUser>> DeleteHouseUser(int id)
        {
            var result = await _service.DeleteHouseUser(id);
            if (result == null)
                return NotFound("Couldn't find the user.");
            return Ok(result);
        }
    }
}
