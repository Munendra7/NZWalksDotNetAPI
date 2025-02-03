using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NZWalks.Models.DTO;
using NZWalks.Repositories;

namespace NZWalks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            var user = await userManager.FindByNameAsync(loginDTO.UserName);

            if (user != null) 
            {
                var isValid = await userManager.CheckPasswordAsync(user, loginDTO.Password);
                if (isValid)
                {
                    //Get Roles

                    var roles = await userManager.GetRolesAsync(user);

                    if (roles != null)
                    {
                        if (roles.Count == 0)
                        {
                            return BadRequest("User has no roles assigned");
                        }

                        //Create JWT token
                        var jwtToken = tokenRepository.GenerateJSONWebToken(user, roles.ToList());

                        var response = new LoginResponseDTO
                        { JwtToken = jwtToken };

                        return Ok(response);
                    }
                    else
                    {
                        return BadRequest("User has no roles assigned");
                    }
                }
            }

            return BadRequest("Invalid username or password");
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
