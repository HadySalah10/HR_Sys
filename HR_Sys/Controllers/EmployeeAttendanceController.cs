using Microsoft.AspNetCore.Mvc;
using HR_Sys.Models;
using Microsoft.AspNetCore.Http;
using ExcelDataReader;
using Microsoft.AspNetCore.Mvc.Rendering;
using HR_Sys.ViewModels;

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
            if (HttpContext.Session.GetString("attendAdd") == "True") { 
                ViewBag.Employees = new SelectList(_db.Employees.ToList(), "id", "empName");

            return View();
                }
            return View("ErrorPage");
        }
       public IActionResult Show()
        {
            if (HttpContext.Session.GetString("attendDisplay") == "True")
            {
                return View();

            }
            return View("ErrorPage");


        }
        [HttpPost]
     

        public IActionResult Show(IFormFile formFile , [FromServices] IWebHostEnvironment hostingEnvironment)
        {
            try
            {
                if (formFile==null)
                {
                    return View();
                }
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





        private List<EmployeeAttendanceExcelViewModel> GetAttencanceList(string fName)
        {
            var attendance = new List<EmployeeAttendanceExcelViewModel>();
            var fileName = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\files"}" + "\\" + fName;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream =System.IO.File.Open(fileName,FileMode.Open,FileAccess.Read)) 
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream)) 
                {
                    while (reader.Read())
                    {
                        if (reader.GetValue(0)==null)
                        {
                            continue;
                        }
                           var id = reader.GetValue(0).ToString() == null ? "0" : reader.GetValue(0).ToString();
                            var attendanceTime= reader.GetValue(1)==null?"": reader.GetValue(1).ToString();
                           var departureTime = reader.GetValue(2) == null ? "" : reader.GetValue(2).ToString();
                             var DayDate = reader.GetValue(3) == null ? "" : reader.GetValue(3).ToString();
                                
                        var isOff = reader.GetValue(4).ToString();
                       
                        attendance.Add(new EmployeeAttendanceExcelViewModel()
                        {
                            empId=Convert.ToInt32(id),
                            attendanceTime=attendanceTime,
                            departureTime= departureTime,
                            attendaceDay = DayDate,
                            isOff = Convert.ToBoolean(isOff)

                        });
                    }
                }
                attendance = this.generateEmployee(attendance);

            }
            return attendance;
        }

        private List<EmployeeAttendanceExcelViewModel> generateEmployee(List<EmployeeAttendanceExcelViewModel> attendance)
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
