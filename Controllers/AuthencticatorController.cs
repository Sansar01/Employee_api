using Employee_api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthencticatorController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        [Route("GetData")]
        public string  GetData() 
        {
            return "Authenticated with jwt";
        }

        [HttpGet]
        [Route("Details")]
        public string Details()
        {
            return "Authenticated with Details";
        }

        [Authorize]
        [HttpPost]
        public string GetPost(User user)
        {
            return "Authenticated with user" +user.Username;
        }
    }
}
