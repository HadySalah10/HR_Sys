using Microsoft.AspNetCore.Mvc;
using HR_Sys.Models;
using Microsoft.AspNetCore.Http;
using ExcelDataReader;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HR_Sys.Controllers
{
    public class EmployeeAttendanceController : Controller
    {
        HrDBContext _db;

        public EmployeeAttendanceController(HrDBContext db)
        {
            _db = db;   

        }
        public IActionResult Index( )
        {
            ViewBag.Employees = new SelectList(db.Employees.ToList(), "id", "empName");

            return View();
        }
       public IActionResult Show()
        {

            return View(_db.EmployeesAttendance.ToList());
        }
        [HttpPost]
     

        public IActionResult Show(IFormFile formFile , [FromServices] IWebHostEnvironment hostingEnvironment)
        {
            try
            {
                string fileName = $"{hostingEnvironment.WebRootPath}\\files\\{formFile.FileName}";
                using (FileStream fileStream = System.IO.File.Create(fileName))
                {
                    formFile.CopyTo(fileStream);
                    fileStream.Flush();
                }
                var attendance = GetAttencanceList(formFile.FileName);
                ViewBag.Error = "";
                ViewBag.Path = fileName;
                return View(attendance);

            }
            catch (Exception)
            {
                ViewBag.Error = "البيانات اللي ادخلتها ربما تكون غير صحيحه";
                return View();

                throw;
            }
          

        }
        [HttpPost]

        public IActionResult saveInDataBase(List<EmployeeAttendance> employeeAttendances, IFormFile pathFile)
        {


            return RedirectToAction();
        }





        private List<EmployeeAttendance> GetAttencanceList(string fName)
        {
            var attendance = new List<EmployeeAttendance>();
            var fileName = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\files"}" + "\\" + fName;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream =System.IO.File.Open(fileName,FileMode.Open,FileAccess.Read)) 
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream)) 
                {
                    while (reader.Read())
                    {
                       var id= reader.GetValue(0).ToString();
                        var attendanceTime= reader.GetValue(1).ToString();
                       var departureTime =  reader.GetValue(2).ToString();
                       var isOff = reader.GetValue(3).ToString();
                       
                        attendance.Add(new EmployeeAttendance()
                        {
                            empId=Convert.ToInt32(id),
                            attendanceTime=Convert.ToDateTime(attendanceTime),
                            departureTime= Convert.ToDateTime(departureTime),
                            isOff= Convert.ToBoolean(isOff),

                        });
                    }
                }
                attendance = this.generateEmployee(attendance);

            }
            return attendance;
        }

        private List<EmployeeAttendance> generateEmployee(List<EmployeeAttendance> attendance)
        {
            var idsEmployee = attendance.Select(s => s.empId).ToList();
            var employees = _db.Employees.Where(a => idsEmployee.Contains(a.id)).ToList();
            int i = 0;
            while (i < employees.Count)
            {
                for (int j = 0; j < attendance.Count; j++)
                {
                    if (employees[i].id == attendance[j].empId)
                    {
                        attendance[j].Employee = employees[i];

                    }

                }
                i++;

            }
            return attendance;
        }
    }
}
