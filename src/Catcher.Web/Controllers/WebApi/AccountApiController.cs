using Catcher.Service.AccountService;
using Catcher.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catcher.Web.Controllers.WebApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountApiController : ControllerBase
    {
        private readonly ILoginService loginService;

        public AccountApiController(ILoginService loginService)
        {
            this.loginService = loginService;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public HttpResModel<string> Login([FromBody] LoginViewModel model, [FromQuery] string redirectUri)
        {
            HttpResModel<string> req = new() { Code = ApiCode.Success, Message = "Success" };
            if (loginService.IsValid(model.User, model.Mema))
            {
                req.Code = ApiCode.Fail;
                req.Message = "Fail";
                req.Data = "帳號或密碼有誤";
                return req;
            }
            return req;
        }
    }
}
