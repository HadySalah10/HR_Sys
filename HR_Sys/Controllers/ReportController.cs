﻿ using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public  IActionResult Index(int searchinput)
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
        public IActionResult invoice(int empId)
        {
            return View();
        }
    }
}
