using Microsoft.AspNetCore.Mvc;

namespace HR_Sys.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
