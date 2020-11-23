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
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;

        public LoginController(IConfiguration config)
        {
            _config = config;
        }
        [HttpGet]
        public IActionResult Login(string Email, string Password)
        {
            UserModel login = new UserModel();
            login.email = Email;
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
            MongoManager dbManager = new MongoManager("Data_Classifier");
            var recs = dbManager.LoadRecords<UserModel>("Users");
            foreach (var rec in recs)
            {
                if (login.email == rec.email && login.Password == rec.Password)
                {
                    user = new UserModel { Id=rec.Id, email = rec.email, Password = rec.Password };
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
                new Claim(JwtRegisteredClaimNames.Sub,userInfo.email),
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
        //[Authorize]
        [HttpPost("CreateAccount")]
        public string Post(UserModel user)
        {
            MongoManager dbManager = new MongoManager("Data_Classifier");
            dbManager.InsertRecord<UserModel>("Users", user);
            //var identity = HttpContext.User.Identity as ClaimsIdentity;
            //IList<Claim> claim = identity.Claims.ToList();
            //var userName = claim[0].Value;
            return "Succes!";
        }

        //[Authorize]
        [HttpGet("GetValues")]
        public ActionResult<string> Get()
        {
            MongoManager dbManager = new MongoManager("Data_Classifier");
            List<string> list = dbManager.LoadRecords<string>("Users");
            return list.Count.ToString();
        }
    }
}