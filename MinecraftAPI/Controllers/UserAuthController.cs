using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MinecraftAPI.APIInterfaces;
using MinecraftAPI.DB;
using MinecraftAPI.Models;
using MinecraftAPI.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinecraftAPI.Controllers
{
    [ApiController]
    public class UserAuthController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _config;

        public UserAuthController(UserManager<User> userManager, ITokenService tokenService, IConfiguration config)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _config = config;
        }

        [HttpPost]
        [Route("api/auth/signup")]
        public async Task<IActionResult> SignUp([FromBody] UserAuthModel authData)
        {
            User user = new User() { UserName = authData.Username };

            var register = await _userManager.CreateAsync(user, authData.Password);

            if(register.Succeeded)
            {
                return Ok();
            }
            return BadRequest("Username is already taken");
        }

        [HttpPost]
        [Route("api/auth/login")]
        public async Task Login([FromBody] UserAuthModel authData)
        {
            var user = await _userManager.FindByNameAsync(authData.Username);

            if(user != null)
            {
                CookieOptions tokenCookieOptions = new CookieOptions();
                tokenCookieOptions.Expires = DateTime.Now.AddHours(3);
                tokenCookieOptions.HttpOnly = true;

                Response.Cookies.Append("JWtoken", 
                    _tokenService.GetJWToken(user, _config.GetValue<string>("TokenIssuer"), _config.GetValue<string>("JWTSecretKey")), 
                    tokenCookieOptions
                );

                CookieOptions secondaryCookieOption = new CookieOptions();
                secondaryCookieOption.Expires = DateTime.Now.AddHours(3);
                Response.Cookies.Append("loggedIn", "true", secondaryCookieOption);

                Response.StatusCode = 200;
            }
            else
            {
                Response.StatusCode = 400;
            }
        }
    }
}
