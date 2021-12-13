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

        public ActionResult index()
        {

            return View(new List<EmpGeneralSettingViewModel>());
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
                    // الاجازات الاسبوعية
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
            EmpGeneralSettingViewModel obj = _db.EmpGeneralSettingViewModel.Where(n => n.id == empGeneral.id).FirstOrDefault();
            obj.requiredExtraHours = empGeneral.requiredExtraHours; 
            obj.requiredDeductHours = empGeneral.requiredDeductHours;   
            obj.idDayHolday1 = empGeneral.idDayHolday1; 
            obj.idDayHolday2 = empGeneral.idDayHolday2;
            _db.SaveChanges();

            return RedirectToAction("Index", "Employee");

        }
        public ActionResult delete (int id)
        {
            EmpGeneralSettingViewModel obj = _db.EmpGeneralSettingViewModel.Find (id);
            _db.EmpGeneralSettingViewModel.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("index");

        }
    }
}
