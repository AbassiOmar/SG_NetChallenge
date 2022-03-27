using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SG_Net_Challenge.Domain.Configurations;
using SG_Net_Challenge.Domain.Dto;

namespace SG_Net_Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IOptions<AppsettingConfiguration> appsettingConfiguration;
        public LoginController(IOptions<AppsettingConfiguration> appsettingConfiguration)
        {
            this.appsettingConfiguration = appsettingConfiguration;
        }


        [HttpPost, Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO data)
        {
            IActionResult response = Unauthorized();
            var user = await AuthenticateUser(data);
            if (data != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { Token = tokenString, Message = "Success" });
            }
            return response;
        }

        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            return new string[] { accessToken };
        }

        private string GenerateJSONWebToken(LoginDTO userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.appsettingConfiguration.Value.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(this.appsettingConfiguration.Value.Issuer,
             this.appsettingConfiguration.Value.Issuer,
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<LoginDTO> AuthenticateUser(LoginDTO login)
        {
            LoginDTO user = null;

            //Validate the User Credentials      
            //Demo Purpose, I have Passed HardCoded User Information      
            if (login.UserName == "admin")
            {
                user = new LoginDTO { UserName = "admin", Password = "0000" };
            }
            return user;
        }
    }
}