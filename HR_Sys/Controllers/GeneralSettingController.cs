using HR_Sys.Models;
using HR_Sys.ViewModels;
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

    
        public ActionResult EmpGeneralSetting(string ssn)
        {

            var employee=  _db.Employees.Where(sn=>sn.empSsn==ssn).Select(s=>new {s.id,s.empName}).FirstOrDefault();
            ViewBag.idEmployee = employee;
            ViewBag.nameEmployee = employee;

            var holidays = new SelectList(_db.Days.ToList(), "id", "daysName");
            ViewBag.holidays1 = holidays;
            ViewBag.holidays2 = holidays;

            return View();
        }
        [HttpPost]
        public ActionResult EmpGeneralSetting(EmpGeneralSettingViewModel empGeneral )
        {
            if (ModelState.IsValid)
            {

                Employee EMP = _db.Employees.Where(s => s.id == empGeneral.id).FirstOrDefault();
                EMP.requiredExtraHours = empGeneral.requiredExtraHours;
                EMP.requiredDeductHours = empGeneral.requiredDeductHours;

                TypesOfVacationsEmp typesOfVacationsEmp = new TypesOfVacationsEmp()
                {
                    empId = empGeneral.id,
                    vacId = 1,
                    idDays = empGeneral.idDayHolday1
                   
                };
                TypesOfVacationsEmp typesOfVacationsEmp2 = new TypesOfVacationsEmp()
                {
                    empId = empGeneral.id,
                    vacId = 1,
                    idDays = empGeneral.idDayHolday2

                };



                _db.SaveChanges();

                RedirectToAction("Index", "Employee");

            }

            else
            {

                var holidays = new SelectList(_db.Days.ToList(), "id", "daysName");
                ViewBag.holidays1 = holidays;
                ViewBag.holidays2 = holidays;

                return View();
            }
            return View();


        }

        public ActionResult EditGeneralSetting(int id)
        {
            return View();
        
        }

        [HttpPost]
        public ActionResult EditGeneralSetting(EmpGeneralSettingViewModel empGeneral)
        {
            Employee EMP = _db.Employees.Where(s => s.id == empGeneral.id).FirstOrDefault();
            EMP.requiredExtraHours = empGeneral.requiredExtraHours;
            EMP.requiredDeductHours = empGeneral.requiredDeductHours;
            List <TypesOfVacationsEmp> TV = _db.TypesOfVacationsEmps.TakeWhile(n => n.id == empGeneral.id).ToList();
            TV[0].vacId = 1;
            TV[1].vacId = 1;
            TV[0].idDays = empGeneral.idDayHolday1;
            TV[1].idDays = empGeneral.idDayHolday2;

            _db.SaveChanges();


            return RedirectToAction("Index", "Employee");

        }
    }
}
