 using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using HR_Sys.Models;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;
using X.PagedList;

namespace HR_Sys.Controllers
{
    public class ReportController : Controller
    {
        HrDBContext db;
        public ReportController(HrDBContext db)
        {
            this.db = db;

        }
        public  IActionResult Index()
        {
            if (HttpContext.Session.GetString("reportDisplay") == "True")
            {
                var report = db.EmpReports.ToList();
                
                ViewBag.months = new SelectList(db.Months.ToList(), "id", "nameMonth");
                //var item = db.EmpReports.AsNoTracking().OrderBy(p => p.empId);
                //var model = await PagingList<EmpReport>.CreateAsync(item, 2, page);
                //if (searchinput != null)
                //{
                //    report = (List<EmpReport>)report.Where(n => n.idmonth.ToString() == searchinput.ToString());

                //}
                return View(report);
            }
            return View("ErrorPage");
        }

        public IActionResult searchByMonth(int idmonth, int page = 1, int pageSize = 2)
        {
            page = page > 0 ? page : 1;

            pageSize = pageSize > 0 ? pageSize : 7;
            var emps = db.EmpReports.Where(n=>n.idmonth== idmonth).ToList();
            ViewBag.month = idmonth;
            return PartialView(emps.ToPagedList(page, pageSize));

        }

        public IActionResult invoice(int empId)
        {
            return View();
        }
    }
}
