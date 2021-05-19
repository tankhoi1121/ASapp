using ASapp.Models;
using Microsoft.AspNetCore.Authorization;
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


        [Route("[action]")]
        [HttpGet]
        [ResponseCache(Duration = 30)]
        public List<User> Load()
        {
            List<User> users = new List<User>();
            users.Add(new Models.User { Username = "mit", Password = "electric" });
            users.Add(new Models.User { Username = "change", Password = "pwd" });
            users.Add(new Models.User { Username = DateTime.UtcNow.ToString(), Password = "pwd" });
            return users;
        }

        [Route("[action]")]
        [HttpGet]
        [ResponseCache(Duration = 5, VaryByQueryKeys = new[] { "username" })]
        public User LoadByUsername(string username, int? _times)
        {
            List<User> users = new List<User>();
            if (_times == null)
            {

                users.Add(new Models.User { Username = "mit", Password = DateTime.UtcNow.ToString() });
                users.Add(new Models.User { Username = "change", Password = DateTime.UtcNow.ToString() });
                users.Add(new Models.User { Username = DateTime.UtcNow.ToString(), Password = "pwd" });
            }
            else
            {
                return new User { Username = "in search of incredible", Password = "AAdWb" };
            }

            return users.SingleOrDefault(x => x.Username == username);
        }
    }
}
