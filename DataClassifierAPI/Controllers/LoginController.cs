using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DataClassifierAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DataClassifierAPI.Controllers
{
    [Route("https://vandermerwe99.github.io/DataClassifierAPI//[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;

        public LoginController(IConfiguration config)
        {
            _config = config;
        }
        [HttpGet]
        public IActionResult Login(string Username, string Password)
        {
            UserModel login = new UserModel();
            login.username = Username;
            login.Password = Password;
            IActionResult response = Unauthorized();

            var user = AuthenticateUser(login);

            if (user != null)
            {
                var tokenStr = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenStr });
            }
            return response;
        }

        private UserModel AuthenticateUser(UserModel login)
        {
            UserModel user = null;
            //if (login.UserName == "AuthmyAPI" && login.Password == "please")
            //{
            //    user = new UserModel { UserName = "AuthmyAPI", Email = "Test@mail.com", Password = "please" };
            //}
            MongoManager dbManager = new MongoManager("Addressbook");
            var recs = dbManager.LoadRecords<UserModel>("Users");
            foreach (var rec in recs)
            {
                if (login.username == rec.username && login.Password == rec.Password)
                {
                    user = new UserModel { Id=rec.Id, username = rec.username, email = rec.email, Password = rec.Password, DateOfBirth = rec.DateOfBirth };
                }
            }
            return user;
        }

        private string GenerateJSONWebToken(UserModel userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,userInfo.username),
                new Claim(JwtRegisteredClaimNames.Email,userInfo.email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            var encodeToken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodeToken;
        }
        [Authorize]
        [HttpPost("Post")]
        public string Post()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            IList<Claim> claim = identity.Claims.ToList();
            var userName = claim[0].Value;
            return "Welcome " + userName;

        }
        [Authorize]
        [HttpGet("GetValue")]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Val1", "Vale2", "Val3" };
        }
    }
}