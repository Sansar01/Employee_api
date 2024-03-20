using Employee_api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Employee_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _configuration;
        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        private User AuthenticateUser(User user) 
        {
            User _user = null;
            if(user.Username == "SansarTech" && user.Password == "Techharvest@11") 
            {
                _user = new User { Username = "Sansar Tiwari" };
            }
            return _user;
        }

        private string GenerateToken(User user) 
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var credentials =  new SigningCredentials(securitykey,SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"],null,expires:DateTime.Now.AddMinutes(1),signingCredentials:credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(User user)
        {
            IActionResult response = Unauthorized();
            var user_ = AuthenticateUser(user);     
            if(user_ != null) 
            {
              var token = GenerateToken(user_);
                response  = Ok(new {token = token });
            }
            return response;
        }
    }
}
