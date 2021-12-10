using HR_Sys.Models;
using HR_Sys.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HR_Sys.Controllers
{
    public class EmployeeController : Controller
    {

        //iticontext 
        HrDBContext _db;
        public EmployeeController(HrDBContext context)
        {
            _db = context;   
        }

        // GET: EmployeeController
        public ActionResult Index()
        {

            return View(_db.Employees.ToList());
        }


        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            ViewBag.nationalities = new SelectList(_db.Nationalities.ToList(), "id", "nationalityName");
            ViewBag.departments = new SelectList(_db.Departments.ToList(), "id", "deptName");

            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        public ActionResult Create(CreateEmployeeViewModel employee )
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Employee employeeModel = new Employee()
                    {
                        empName =employee.empName,
                        empAddress = employee.empAddress,
                        phoneNum=employee.phoneNum,
                        phoneNum2=employee.phoneNum2,
                        empGender=employee.empGender,
                        nationalityId=employee.nationalityId,
                        empDateOfBirth=employee.empDateOfBirth,
                        empSsn=employee.empSsn,
                        empHireDate=employee.empHireDate,
                        empNetSalary=employee.empNetSalary,
                        empNonNetSalary=employee.empNonNetSalary,
                        empGrossSalary=employee.empGrossSalary,
                        requiredAttendanceTime=employee.requiredAttendanceTime,
                        requiredDepartureTime=employee.requiredDepartureTime,
                        requiredSalaryPerHour=employee.requiredSalaryPerHour,
                        requiredDaysPerMonth=employee.requiredDaysPerMonth,
                        deptid=employee.deptid,

                    };
                    _db.Employees.Add(employeeModel);
                    _db.SaveChanges();

                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    ViewBag.nationalities = new SelectList(_db.Nationalities.ToList(), "id", "nationalityName");
                    ViewBag.departments = new SelectList(_db.Departments.ToList(), "id", "deptName");


                    return View();

                }
            }
            catch
            {
                ViewBag.nationalities = new SelectList(_db.Nationalities.ToList(), "id", "nationalityName");
                ViewBag.departments = new SelectList(_db.Departments.ToList(), "id", "deptName");
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            var check = _db.Employees.Find(id);
            if (check.id>0|| check!=null )
                _db.Employees.Remove(check);
            _db.SaveChanges();

          return   RedirectToAction("Index");

            
            
        }



    }
}
