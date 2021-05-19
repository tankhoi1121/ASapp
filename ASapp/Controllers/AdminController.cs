using ASapp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ASapp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        public AdminController() { }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Login([FromBody] User user)
        {
            var Claims = new List<Claim>
            {
                new Claim("type", "Admin"),
            };
            var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Change for better"));
            var Token = new JwtSecurityToken(
                "https://fbi-demo.com",
                "https://fbi-demo.com",
                Claims,
                expires: DateTime.Now.AddDays(30.0),
                signingCredentials: new SigningCredentials(Key, SecurityAlgorithms.HmacSha256)
            );

            return new OkObjectResult(new JwtSecurityTokenHandler().WriteToken(Token));
        }
    }
}
