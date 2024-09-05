using JWTTokenSample.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics.Eventing.Reader;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace JWTTokenSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration config;

        public LoginController(IConfiguration _config)
        {
            this.config = _config;
        }

        [HttpPost]
        [Route("LoginUser")]
        public IActionResult authLogin(AuthUser user)
        {
            IActionResult response;

            var IsUser = ControlUser(user.UserName, user.Password);
            if (IsUser)
            {
                var tokenString = createJsonWebToken(user);
                response = Ok(new { token = tokenString });
            }
            else
                response = Unauthorized();

            return response;
        }

        private object createJsonWebToken(AuthUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Key"]));

            var credantials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(config["JWT:Issuer"], config["JWT:Issuer"], null, DateTime.Now.AddMinutes(30), signingCredentials: credantials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private bool ControlUser(string userName, string password)
        {
            bool result = false;

            if(userName == "admin" && password =="123456")
                result = true;

            return result;
        }
    }
}
