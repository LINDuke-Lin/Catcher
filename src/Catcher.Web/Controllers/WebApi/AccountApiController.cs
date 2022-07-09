using Catcher.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catcher.Web.Controllers.WebApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountApiController : ControllerBase
    {
      
        [HttpPost("Login")]
        [AllowAnonymous]
        public void Login([FromBody] LoginViewModel User)
        {
           // logger.LogDebug($"{User.Mema}, {User.User}");

            string a = "";
        }
    }
}
