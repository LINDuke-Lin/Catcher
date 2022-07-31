using Catcher.Service.Services;

namespace Catcher.Web.Controllers.WebApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorReportApiController : ControllerBase
    {
        private readonly IErrorService _errorService;

        public ErrorReportApiController(IErrorService errorService)
        {
            _errorService = errorService;
        }


        [HttpGet("Create")]
        public void Create()
        {
            _errorService.Create();
        }
    }
}
