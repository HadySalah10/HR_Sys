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
        public  IActionResult Index(int idmonth, string searchString, int year, int page = 1, int pageSize = 2)
        {
            if (HttpContext.Session.GetString("reportDisplay") == "True")
            {
                
                ViewBag.months = new SelectList(db.Months.ToList(), "id", "nameMonth",idmonth);

                page = page > 0 ? page : 1;

                pageSize = pageSize > 0 ? pageSize : 7;
                var emps = db.EmpReports.Where(n => n.idmonth == idmonth).ToPagedList(page, pageSize);
                ViewBag.month = idmonth;
                ViewBag.search = searchString;
                ViewBag.pageNum = page;
                ViewBag.year = year;


                return View(emps);
            }
            return View("ErrorPage");
        }

        public IActionResult search(int idmonth, string searchString, int year, int page = 1, int pageSize = 2)
        {
            page = page > 0 ? page : 1;

            pageSize = pageSize > 0 ? pageSize : 7;

            ViewBag.month = idmonth;
            ViewBag.pageNum = page;
            ViewBag.search = searchString;
            ViewBag.year = year;    

            var result = db.EmpReports.ToList();

            if (!String.IsNullOrEmpty(searchString) && idmonth != 0 && year != 0)
            {
                result = result.Where(n => n.Employees.empName.Contains(searchString) && n.idmonth == idmonth && n.year == year).ToList();



            }
            else if (!String.IsNullOrEmpty(searchString) && idmonth != 0)
            {
                result = result.Where(n => n.Employees.empName.Contains(searchString) && n.idmonth == idmonth).ToList();



            }
            else if (!String.IsNullOrEmpty(searchString) && year != 0)
            {
                result = result.Where(n => n.Employees.empName.Contains(searchString) && n.year == year).ToList();



            }
            else if (idmonth != 0 && year != 0)
            {
                result = result.Where(n => n.idmonth == idmonth && n.year == year).ToList();



            }


            else if (!String.IsNullOrEmpty(searchString))
            {

                result = result.Where(n => n.Employees.empName.Contains(searchString)).ToList();




            }

            else if (idmonth != 0)
            {

                result = result.Where(n => n.idmonth == idmonth).ToList();




            }
            else if (year != 0)
            {
                int dateOFYear = DateTime.Now.Year;
                if (year >= 2008 && year <= dateOFYear)
                {
                    result = result.Where(n => n.year == year).ToList();



                }
                else
                {


                }



            }


            return PartialView(result.ToPagedList(page, pageSize));
        }




        

        //public IActionResult searchByName(string searchString, int page = 1, int pageSize = 2)
        //{
        //    page = page > 0 ? page : 1;

        //    pageSize = pageSize > 0 ? pageSize : 7;

        //    var employee = db.EmpReports.ToList();

        //    if (!String.IsNullOrEmpty(searchString))
        //    {

        //        employee = employee.Where(n => n.Employees.empName.Contains(searchString)).ToList();

        //    }


        //}


        public IActionResult invoice(int empId)
        {
            return View();
        }
    }
}
