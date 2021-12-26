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
            return View(_db.Employees.ToList());
        }

    
        public ActionResult EmpGeneralSetting(string ssn)
        {

            var employee=  _db.Employees.Where(sn=>sn.empSsn==ssn).Select(s=>new {s.id,s.empName}).FirstOrDefault();
            ViewBag.idEmployee = employee.id;
            ViewBag.nameEmployee = employee.empName;

            var holidays = new SelectList(_db.Days.ToList(), "id", "daysName");
            ViewBag.holidays1 = holidays;
            ViewBag.holidays2 = holidays;

            return View();
        }
        [HttpPost]
        public ActionResult EmpGeneralSetting(EmpGeneralSettingViewModel empGeneral )
        {
            ViewBag.idEmployee = empGeneral.id;
            if (ModelState.IsValid)
            {

                Employee EMP = _db.Employees.Where(s => s.id == empGeneral.id).FirstOrDefault();
             
                EMP.requiredExtraHours = empGeneral.requiredExtraHours;
                EMP.requiredDeductHours = empGeneral.requiredDeductHours;


                TypesOfVacationsEmp typesOfVacationsEmp1 = new TypesOfVacationsEmp()
                {
                    empId = empGeneral.id,
                    vacId = 1,
                    idDays = empGeneral.idDayHolday1
                };
                _db.TypesOfVacationsEmps.Add(typesOfVacationsEmp1);


                if (empGeneral.idDayHolday2 > 0)
                {
                    TypesOfVacationsEmp typesOfVacationsEmp2 = new TypesOfVacationsEmp()
                    {
                        empId = empGeneral.id,
                        vacId = 1,
                        idDays = empGeneral.idDayHolday2

                    };
                    _db.TypesOfVacationsEmps.Add(typesOfVacationsEmp2);


                }





                _db.SaveChanges();
                return RedirectToAction("Index", "Employee");

            }
            else
            {

                var holidays = new SelectList(_db.Days.ToList(), "id", "daysName");
                ViewBag.holidays1 = holidays;
                ViewBag.holidays2 = holidays;

                return View();
            }

     

        }

        public ActionResult EditGeneralSetting(int id)
        {
            var tVE = _db.TypesOfVacationsEmps.Where(a => a.id == id).ToList();
            if (tVE != null) { 
                var holidays = new SelectList(_db.Days.ToList(), "id", "daysName",tVE[0].idDays);
                var holidays2 = new SelectList(_db.Days.ToList(), "id", "daysName",tVE[1].idDays);
            
                ViewBag.holidays1 = holidays;
                ViewBag.holidays2 = holidays2;
            }
            else
            {
                var holidays = new SelectList(_db.Days.ToList(), "id", "daysName");

                ViewBag.holidays1 = holidays;
                ViewBag.holidays2 = holidays;

            }
            return View();
        
        }

        [HttpPost]
        public ActionResult EditGeneralSetting(EmpGeneralSettingViewModel empGeneral)
        {
           

            Employee obj = _db.Employees.Find(empGeneral.id);
            obj.requiredExtraHours = empGeneral.requiredExtraHours; 
            obj.requiredDeductHours = empGeneral.requiredDeductHours; 
            List <TypesOfVacationsEmp> tv = _db.TypesOfVacationsEmps.Where(n => n.empId == empGeneral.id).ToList();

            if (empGeneral.idDayHolday1 > 0)
            {
                tv[0].idDays = empGeneral.idDayHolday1;

            }

            if (empGeneral.idDayHolday2 > 0)
            {
                tv[1].idDays = empGeneral.idDayHolday2;
            }

            _db.SaveChanges();

            return RedirectToAction("Index", "Employee");

        }



 
    }
}
