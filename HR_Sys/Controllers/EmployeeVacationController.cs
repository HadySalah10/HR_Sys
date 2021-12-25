using Microsoft.AspNetCore.Mvc;
using HR_Sys.ViewModels;
using HR_Sys.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HR_Sys.Controllers
{
    public class EmployeeVacationController : Controller
    {

        HrDBContext db;
        public EmployeeVacationController(HrDBContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View(db.TypesOfVacationsEmps.ToList());
        }

        public IActionResult create()
        {
            ViewBag.emps = new SelectList(db.Employees.ToList(), "id", "empName");

            return View();
        
        }

        [HttpPost]
        public IActionResult create(TypesOfVactionViewModel vacation)
        {
            if (ModelState.IsValid)
            {
                var dayName = vacation.date.Value.DayOfWeek.ToString();
                int idDay = db.Days.Where(n => n.displayNameEnglish == dayName).Select(n => n.id).FirstOrDefault();
                //var emp = db.Employees.Where(n => n.empName == vacation.empName).SingleOrDefault();
                TypesOfVacationsEmp EmployeeVacation = new TypesOfVacationsEmp();
                EmployeeVacation.date = vacation.date;
                EmployeeVacation.empId = vacation.empId;
                EmployeeVacation.vacId = vacation.vacId;
                EmployeeVacation.idDays = idDay;
                
                


                db.TypesOfVacationsEmps.Add(EmployeeVacation);
                db.SaveChanges();       
               
            }
            return RedirectToAction("Index");


        }

        public IActionResult delete(int id)
        {
            var vaction = db.TypesOfVacationsEmps.Find(id);
            if (vaction != null)
            {
                db.TypesOfVacationsEmps.Remove(vaction);
                db.SaveChanges();
            
            }

            return RedirectToAction("Index");



        }





    }
}
