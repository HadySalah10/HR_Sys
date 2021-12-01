using Microsoft.AspNetCore.Mvc;

namespace HR_Sys.Controllers
{
    public class HRController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
