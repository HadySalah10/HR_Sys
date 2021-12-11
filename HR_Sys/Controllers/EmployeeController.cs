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
        public IActionResult Index()

        {

            return View(_db.Employees.ToList());
        }


        // GET: EmployeeController/Create
        public IActionResult Create()
        {
            ViewBag.nationalities = new SelectList(_db.Nationalities.ToList(), "id", "nationalityName");
            ViewBag.departments = new SelectList(_db.Departments.ToList(), "id", "deptName");

            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        public IActionResult Create(CreateEmployeeViewModel employee )
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
                    _db.Add(employeeModel);
                    _db.SaveChanges();
                  
                
                    return RedirectToAction("EmpGeneralSetting", "GeneralSetting", new { ssn = employeeModel.empSsn });



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
        public IActionResult Edit(int id)
        {
            var Employee = _db.Employees.Find(id);
            CreateEmployeeViewModel employeeViewMOdel = new CreateEmployeeViewModel
            {
               EmployeeID = Employee.id,
               empName = Employee.empName,
               empAddress = Employee.empAddress,
               empGender=Employee.empGender,
               empDateOfBirth=Employee.empDateOfBirth,
               empHireDate=Employee.empHireDate,
               empGrossSalary=Employee.empGrossSalary,
               empNetSalary=Employee.empNetSalary,
               empNonNetSalary=Employee.empNonNetSalary,
               empSsn=Employee.empSsn,
               requiredAttendanceTime=Employee.requiredAttendanceTime,
               requiredDaysPerMonth=Employee.requiredDaysPerMonth,
               requiredDepartureTime=Employee.requiredDepartureTime,
               requiredSalaryPerHour=Employee.requiredSalaryPerHour,  
               deptid=Employee.deptid,
               nationalityId=Employee.nationalityId,
               phoneNum=Employee.phoneNum,
               phoneNum2=Employee.phoneNum2

            };
            ViewBag.nationalities = new SelectList(_db.Nationalities.ToList(), "id", "nationalityName");
            
            ViewBag.departments = new SelectList(_db.Departments.ToList(), "id", "deptName");

            return View(employeeViewMOdel);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        public IActionResult Edit(CreateEmployeeViewModel Employee)
        {
            try
            {
                
                if (ModelState.IsValid)
                {
                    var employeeFromDb = _db.Employees.Find(Employee.EmployeeID);


                    employeeFromDb.empName = Employee.empName;
                    employeeFromDb.empAddress = Employee.empAddress;
                    employeeFromDb.empGender = Employee.empGender;
                    employeeFromDb.empDateOfBirth = Employee.empDateOfBirth;
                    employeeFromDb.empHireDate = Employee.empHireDate;
                    employeeFromDb.empGrossSalary = Employee.empGrossSalary;
                    employeeFromDb.empNetSalary = Employee.empNetSalary;
                    employeeFromDb.empNonNetSalary = Employee.empNonNetSalary;
                    employeeFromDb.empSsn = Employee.empSsn;
                    employeeFromDb.requiredAttendanceTime = Employee.requiredAttendanceTime;
                    employeeFromDb.requiredDaysPerMonth = Employee.requiredDaysPerMonth;
                    employeeFromDb.requiredDepartureTime = Employee.requiredDepartureTime;
                    employeeFromDb.requiredSalaryPerHour = Employee.requiredSalaryPerHour;
                    employeeFromDb.deptid = Employee.deptid;
                    employeeFromDb.nationalityId = Employee.nationalityId;
                    employeeFromDb.phoneNum = Employee.phoneNum;
                    employeeFromDb.phoneNum2 = Employee.phoneNum2;

                    
                    
                    _db.SaveChanges();
                    return RedirectToAction(nameof(Index));

                }
                return View();
            }
            catch
            {
                return View();
            }
        }

    

        // GET: EmployeeController/Delete/5
        public IActionResult Delete(int id)
        {
            var check = _db.Employees.Find(id);
            if (check.id>0|| check!=null )
                _db.Employees.Remove(check);
            _db.SaveChanges();

          return   RedirectToAction("Index");

            
            
        }


        public IActionResult checkSsn(string empSsn)
        {
            var employee = _db.Employees.Where(u => u.empSsn == empSsn).FirstOrDefault();
            if (employee != null)
                return Json(false);
                return Json(true);

        }


    }
}
