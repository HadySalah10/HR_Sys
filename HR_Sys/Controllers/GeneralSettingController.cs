﻿using HR_Sys.Models;
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

      
        public IActionResult Index()
        {
            return View(); 
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
    }
}
