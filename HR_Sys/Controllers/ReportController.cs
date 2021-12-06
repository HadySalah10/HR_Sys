using Microsoft.AspNetCore.Mvc;
using HR_Sys.Models;

namespace HR_Sys.Controllers
{
    public class ReportController : Controller
    {
        HrDBContext db;
        public ReportController(HrDBContext db)
        {
            this.db = db;

        }
        public IActionResult Index()
        {
            return View(db.EmpReports.ToList());
        }
    }
}
