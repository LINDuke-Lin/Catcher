namespace Catcher.Web.Controllers
{
    public class ReportController : Controller
    {
        private readonly ILogger<ReportController> logger;

        public ReportController(ILogger<ReportController> logger)
        {
            this.logger = logger;
        }

        public IActionResult ErrorProportion()
        {
            return View();
        }
    }
}