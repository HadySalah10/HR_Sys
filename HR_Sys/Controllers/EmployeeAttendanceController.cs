using Microsoft.AspNetCore.Mvc;
using HR_Sys.Models;
using Microsoft.AspNetCore.Http;
using ExcelDataReader;

namespace HR_Sys.Controllers
{
    public class EmployeeAttendanceController : Controller
    {
        HrDBContext db;
        public EmployeeAttendanceController(HrDBContext db)
        {
            this.db = db;   

        }
        public IActionResult Index(int empId)
        {
            return View();
        }
       public IActionResult Show()
        {

            return View(db.EmployeesAttendance.ToList());
        }
        [HttpPost]
     

        public IActionResult Show(IFormFile formFile , [FromServices] IWebHostEnvironment hostingEnvironment)
        {
            string fileName = $"{hostingEnvironment.WebRootPath}\\files\\{formFile.FileName}";
            using (FileStream fileStream = System.IO.File.Create(fileName))
            {
                formFile.CopyTo(fileStream);
                fileStream.Flush();
            }
            var attendance = this.GetAttencanceList(formFile.FileName);

                return View(attendance);
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

            }
            return attendance;
        }
    }
}
