using Catcher.Service.Helpers;

namespace Catcher.Web.Controllers.WebApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountApiController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly JwtHelpers _jwtHelper;

        public AccountApiController(ILoginService loginService, JwtHelpers jwtHelper)
        {
            _loginService = loginService;
            _jwtHelper = jwtHelper;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public HttpResModel<string> Login([FromBody] LoginViewModel model, [FromQuery] string redirectUri)
        {
            HttpResModel<string> req = new() { Code = ApiCode.Success, Message = "Success" };
            if (_loginService.IsValid(model.User, model.Mema) == false)
            {
                req.Code = ApiCode.Fail;
                req.Message = "Fail";
                req.Data = "帳號或密碼有誤";
                return req;
            }
            else
            {
                req.Data = _jwtHelper.GenerateToken(model.User);
            }
            return req;
        }
    }
}
