using Microsoft.AspNetCore.Mvc;

namespace HR_Sys.Controllers
{
    public class AnnualHolidays : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
