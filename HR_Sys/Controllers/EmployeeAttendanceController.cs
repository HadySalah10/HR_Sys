using Microsoft.AspNetCore.Mvc;

namespace HR_Sys.Controllers
{
    public class EmployeeAttendanceController : Controller
    {
        public IActionResult Index(int empId)
        {
            return View();
        }


    }
}
