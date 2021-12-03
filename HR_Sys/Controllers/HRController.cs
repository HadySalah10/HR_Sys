using Microsoft.AspNetCore.Mvc;

namespace HR_Sys.Controllers
{
    public class HRController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RegisterHR()
        {

            return View();
        }

        public IActionResult AddValidation()
        {
            return View();
        }
        public IActionResult Permissions() { 

            return View(); 
        
        }

 



    }
}
