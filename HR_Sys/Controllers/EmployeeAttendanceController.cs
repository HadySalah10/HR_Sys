using Microsoft.AspNetCore.Mvc;
using HR_Sys.Models;
namespace HR_Sys.Controllers
{
    public class EmployeeAttendanceController : Controller
    {
        HrDBContext db;
        public EmployeeAttendanceController(HrDBContext db)
        {
            this.db = db;   

        }
        public IActionResult Index(int empId)
        {
            return View();
        }
       public IActionResult Show()
        {

            return View(db.EmployeesAttendance.ToList());
        }

 
    }
}
