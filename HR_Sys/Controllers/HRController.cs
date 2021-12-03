using HR_Sys.Models;
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
        //[HttpPost]  
        //public IActionResult RegisterHR( HR user)
        //{

            
        //}

        public IActionResult AddValidation()
        {
            return View();
        }

 



    }
}
