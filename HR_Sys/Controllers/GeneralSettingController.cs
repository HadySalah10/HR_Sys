using HR_Sys.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HR_Sys.Controllers
{
    public class GeneralSettingController : Controller
    {
        HrDBContext _db;

        public GeneralSettingController(HrDBContext db)
        {
            _db = db;
        }

      
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult EmpGeneralSetting(int id)
        {
            var holidays = new SelectList(_db.Days.ToList(), "id", "daysName");
            ViewBag.holidays1 = holidays;
            ViewBag.holidays2 = holidays;

            return View();
        }

        public ActionResult EditGeneralSetting(int id)
        {
            return View();
        
        }
    }
}
