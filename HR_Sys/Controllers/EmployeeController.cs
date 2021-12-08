using HR_Sys.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace HR_Sys.Controllers
{
    public class EmployeeController : Controller
    {

        //iticontext 
        HrDBContext db;
        public EmployeeController(HrDBContext db)

        {
            this.db = db;   
        }

        // GET: EmployeeController
        public ActionResult Index()
        {
            List<Employee> emps = db.Employees.ToList();
            return View(emps);
  
        }


        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee emp)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(emp);  
                return RedirectToAction(nameof(Index));
            }
            else
            {
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
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee emp)
        {
            if (ModelState.IsValid) 
            {
                Employee selectedfromdatabase = db.Employees.Find(id);
                emp.empName = selectedfromdatabase.empName;
                emp.deptid = selectedfromdatabase.deptid;   
                emp.empAddress = selectedfromdatabase.empAddress;   
                emp.empGender= selectedfromdatabase.empGender;       
                emp.nationalityId = selectedfromdatabase.nationalityId; 
                emp.empHireDate = selectedfromdatabase.empHireDate; 
                emp.empDateOfBirth = selectedfromdatabase.empDateOfBirth;
                emp.empNetSalary = selectedfromdatabase.empNetSalary;
                emp.empGrossSalary = selectedfromdatabase.empGrossSalary;
                emp.empNonNetSalary = selectedfromdatabase.empNonNetSalary;
                emp.requiredDaysPerMonth = selectedfromdatabase.requiredDaysPerMonth;
                emp.requiredDeductHours = selectedfromdatabase.requiredDeductHours;
                emp.requiredExtraHours = selectedfromdatabase.requiredExtraHours;
                emp.requiredSalaryPerHour = selectedfromdatabase.requiredSalaryPerHour;
                emp.requiredAttendanceTime = selectedfromdatabase.requiredAttendanceTime; 
                emp.requiredDepartureTime = selectedfromdatabase.requiredDepartureTime; 
                emp.empSsn = selectedfromdatabase.empSsn;   
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
              
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {

            return RedirectToAction("Index");
        }

      
        //public ActionResult Editsettings(int id)
        //{

        //}



    }
}
