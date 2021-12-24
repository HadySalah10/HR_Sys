﻿ using Microsoft.AspNetCore.Mvc;
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
        public  IActionResult Index(int idmonth, int page = 1, int pageSize = 2)
        {
            if (HttpContext.Session.GetString("reportDisplay") == "True")
            {
                
                ViewBag.months = new SelectList(db.Months.ToList(), "id", "nameMonth",idmonth);

                page = page > 0 ? page : 1;

                pageSize = pageSize > 0 ? pageSize : 7;
                var emps = db.EmpReports.Where(n => n.idmonth == idmonth).ToPagedList(page, pageSize);
                ViewBag.month = idmonth;
                //var item = db.EmpReports.AsNoTracking().OrderBy(p => p.empId);
                //var model = await PagingList<EmpReport>.CreateAsync(item, 2, page);
                //if (searchinput != null)
                //{
                //    report = (List<EmpReport>)report.Where(n => n.idmonth.ToString() == searchinput.ToString());

                //}

                ViewBag.pageNum = page;

                return View(emps);
            }
            return View("ErrorPage");
        }

        public IActionResult searchByMonth(int idmonth, int page = 1, int pageSize = 2)
        {
            page = page > 0 ? page : 1;

            pageSize = pageSize > 0 ? pageSize : 7;
            var emps = db.EmpReports.Where(n=>n.idmonth== idmonth).ToPagedList(page, pageSize);
            ViewBag.month = idmonth;
            return PartialView(emps);

        }

        public IActionResult searchByName(string searchString, int page = 1, int pageSize = 2)
        {
            page = page > 0 ? page : 1;

            pageSize = pageSize > 0 ? pageSize : 7;

            var employee = db.EmpReports.ToList();

            if (!String.IsNullOrEmpty(searchString))
            {

                employee = employee.Where(n => n.Employees.empName.Contains(searchString)).ToList();

            }

            ViewBag.search = searchString;

            return PartialView(employee.ToPagedList(page, pageSize));
        }


        public IActionResult invoice(int empId)
        {
            return View();
        }
    }
}
