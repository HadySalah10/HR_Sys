 using Microsoft.AspNetCore.Mvc;
using HR_Sys.Models;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;

namespace HR_Sys.Controllers
{
    public class ReportController : Controller
    {
        HrDBContext db;
        public ReportController(HrDBContext db)
        {
            this.db = db;

        }
        public async Task<IActionResult> Index(int page=1)
        {
            var item = db.EmpReports.AsNoTracking().OrderBy(p => p.empId);
            var model = await PagingList<EmpReport>.CreateAsync(item, 2, page);
            return View(model);
        }
        public IActionResult invoice(int empId)
        {
            return View();
        }
    }
}
