using AutoMapper;
using chomer_backend.Models;
using chomer_backend.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace chomer_backend.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IMapper _mapper;

        public AccountController(UserManager<User> userManager, ILogger<AccountController> logger, IMapper mapper)
        {
            _userManager = userManager;
            _logger = logger;
            _mapper = mapper;
        }
        [Route("register")]
        [HttpPost]
        public async Task<ActionResult> Register([FromBody] CreateUserDTO userDTO)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var user = _mapper.Map<User>(userDTO);
                user.UserName = userDTO.Email;
                var result = await _userManager.CreateAsync(user, userDTO.Password);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                        ModelState.AddModelError(error.Code, error.Description);
                    return BadRequest(ModelState);
                }
                await _userManager.AddToRoleAsync(user, "User");
                return Accepted();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(Register)}");
                return StatusCode(500, "Something went wrong. Please try again later.");
            }
        }
        //[Route("login")]
        //[HttpPost]
        //public async Task<ActionResult> Login([FromBody] LoginUserDTO userDTO)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);
        //    try
        //    {
        //        var result = await _signInManager.PasswordSignInAsync(userDTO.Email, userDTO.Password, true, false);
        //        if(!result.Succeeded)
        //            return Unauthorized(userDTO);

        //        return Accepted();
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, $"Something went wrong in the {nameof(Login)}");
        //        return StatusCode(500, "Something went wrong. Please try again later.");
        //    }
        //}
    }
}
