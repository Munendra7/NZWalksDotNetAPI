using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NZWalks.Models.DTO;

namespace NZWalks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;

        public AuthController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }


        [HttpPost]
        [Route("login")]
        public IActionResult Login()
        {
            return Ok();
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
        {
            var identityResult = await userManager.CreateAsync(new IdentityUser() { UserName = registerDTO.Username, Email = registerDTO.Username }, registerDTO.Password);

            if (identityResult.Succeeded)
            {
                var user = await userManager.FindByNameAsync(registerDTO.Username);
                if (user == null)
                {
                    return BadRequest("User creation failed.");
                }
                identityResult = await userManager.AddToRolesAsync(user, registerDTO.Roles);

                if (!identityResult.Succeeded)
                {
                    return BadRequest(identityResult.Errors);
                }

                return Ok("User registered successfully");
            }
            else
            {
                return BadRequest(identityResult.Errors);
            }
        }
    }
}
