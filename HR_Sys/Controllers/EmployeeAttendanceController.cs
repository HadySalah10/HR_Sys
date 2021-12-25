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
               // var attendanceToDatabse = GetAttencanceList(attendance);
                return View(attendance);

            }
            catch (Exception)
            {
                ViewBag.Error = "البيانات اللي ادخلتها ربما تكون غير صحيحه";
                return View();

                throw;
            }
          

        }
      
    private List<EmployeeAttendance> GetAttencanceListToDataBase(List<EmployeeAttendanceExcelViewModel> excelViewModels,out Employee employee,out string day, out  DateTime? date)
        {
            List<EmployeeAttendance> attendance =new List<EmployeeAttendance>();
            List<int> ids =new List<int>();
            try
            {
                for (int i = 0; i < excelViewModels.Count; i++)
                {
                    ids.Add(excelViewModels[i].empId);

                }
                var emps = _db.Employees.Where(em => ids.Contains(em.id)).ToList();
               

                 for (int i = 0; i < excelViewModels.Count; i++)
                 {
                    
                    var minusOrAdds1 = 0;
                    float minus = 0;

                    foreach (var emp in emps)
                    {

                        if (emp.id== excelViewModels[i].empId)
                        {


                            // الاجازة الاول 
                            foreach (var item in emp.TypesOfVacationsEmps)
                            {
                                string days = Convert.ToDateTime(excelViewModels[i].attendaceDay).DayOfWeek.ToString();
                                //الاجازة بتاعته
                                if (Convert.ToDateTime(excelViewModels[i].attendaceDay).Date.CompareTo(Convert.ToDateTime(item.date).Date)==0 || (days == item.days.daysName))
                                {
                                    employee=emp;
                                    day=days;
                                    date=item.date;

                                    return attendance;

                                 }
                             }



                            //جه بدري او متأخر
                            if (emp.requiredAttendanceTime.TimeOfDay != Convert.ToDateTime(excelViewModels[i].attendanceTime).TimeOfDay)
                            {
                                //  مشي بدري او متأخر 
                                if (emp.requiredDepartureTime.TimeOfDay != Convert.ToDateTime(excelViewModels[i].departureTime).TimeOfDay)
                                {
                                    //جه متأخر
                                    if (Convert.ToDateTime(excelViewModels[i].attendanceTime).TimeOfDay.TotalHours > emp.requiredAttendanceTime.TimeOfDay.TotalHours)
                                    {
                                        // ساعات الخصم
                                        var minusOrAddDeduct = Math.Abs(Convert.ToDateTime(excelViewModels[i].attendanceTime).TimeOfDay.TotalHours - emp.requiredAttendanceTime.TimeOfDay.TotalHours) * emp.requiredDeductHours;
                                        // كميه الخصم
                                        var deductAmount = minusOrAddDeduct *(float) emp.requiredSalaryPerHour;
                                        //مشي بعد الوقت
                                        if (Convert.ToDateTime(excelViewModels[i].departureTime).TimeOfDay > emp.requiredDepartureTime.TimeOfDay)
                                        {
                                            // ساعات الزيادة
                                            var minusOrAddExtra = (Convert.ToDateTime(excelViewModels[i].departureTime).TimeOfDay.TotalHours - emp.requiredDepartureTime.TimeOfDay.TotalHours) * emp.requiredExtraHours;
                                           // كميه الزيادة
                                           var extraAmount=minusOrAddExtra*(float) emp.requiredSalaryPerHour;
                                            // جه متأخر ومشي بعد الوقت
                                            var attendanceObject = new EmployeeAttendance()
                                            {
                                                empId = excelViewModels[i].empId,
                                                attendanceTime = Convert.ToDateTime(excelViewModels[i].attendanceTime),
                                                departureTime = Convert.ToDateTime(excelViewModels[i].departureTime),
                                                attendaceDay = Convert.ToDateTime(excelViewModels[i].attendaceDay),
                                                extraHours =(float)minusOrAddExtra,
                                                deductHours =(float) minusOrAddDeduct,
                                                deductAmount=(float)deductAmount,
                                                extraAmount=(float)extraAmount




                                            };
                                            attendance.Add(attendanceObject);

                                        }
                                        //مشي قبل الوقت
                                        else
                                        {
                                             minusOrAddDeduct = minusOrAddDeduct+ (Math.Abs(emp.requiredDepartureTime.TimeOfDay.TotalHours - Convert.ToDateTime(excelViewModels[i].departureTime).TimeOfDay.TotalHours) * emp.requiredDeductHours);
                                            var minusOrAddDeductAmount = minusOrAddDeduct * (float)emp.requiredSalaryPerHour;
                                            var attendanceObject = new EmployeeAttendance()
                                            {
                                                empId = excelViewModels[i].empId,
                                                attendanceTime = Convert.ToDateTime(excelViewModels[i].attendanceTime),
                                                departureTime = Convert.ToDateTime(excelViewModels[i].departureTime),
                                                attendaceDay = Convert.ToDateTime(excelViewModels[i].attendaceDay),
                                              
                                                deductHours = (float)minusOrAddDeduct,
                                                deductAmount =(float)minusOrAddDeductAmount,
                                                extraHours=0,
                                                extraAmount=0,



                                            };
                                            attendance.Add(attendanceObject);

                                        }

                                    }
                                   
                                    //جه بدري
                                    else
                                    {
                                        // ساعات الزيادة
                                        float minusOrAddExtra = (float) Math.Abs(Convert.ToDateTime(excelViewModels[i].attendanceTime).TimeOfDay.TotalHours -  emp.requiredAttendanceTime.TimeOfDay.TotalHours )* emp.requiredExtraHours;
                                        var extraAmpunt = (decimal)minusOrAddExtra * emp.requiredSalaryPerHour;
                                        //مشي بعد الوقت
                                        if (Convert.ToDateTime(excelViewModels[i].departureTime).TimeOfDay > emp.requiredDepartureTime.TimeOfDay)
                                        {
                                             minusOrAddExtra =  minusOrAddExtra+ (float)((Convert.ToDateTime(excelViewModels[i].departureTime).TimeOfDay.TotalHours - emp.requiredDepartureTime.TimeOfDay.TotalHours) * emp.requiredExtraHours);
                                            // جه بدري ومشي بعد الوقت
                                           var extraAmpuntForExtra = (decimal)minusOrAddExtra * emp.requiredSalaryPerHour;


                                            var attendanceObject = new EmployeeAttendance()
                                            {
                                                empId = excelViewModels[i].empId,
                                                attendanceTime = Convert.ToDateTime(excelViewModels[i].attendanceTime),
                                                departureTime = Convert.ToDateTime(excelViewModels[i].departureTime),
                                                attendaceDay = Convert.ToDateTime(excelViewModels[i].attendaceDay),
                                                extraHours = (float)minusOrAddExtra,
                                                deductHours=0,
                                                extraAmount=(float)extraAmpuntForExtra,
                                                deductAmount=0,

                                            };
                                            attendance.Add(attendanceObject);

                                        }
                                        //مشي في ميعاده
                                        else if (Convert.ToDateTime(excelViewModels[i].departureTime).TimeOfDay == emp.requiredDepartureTime.TimeOfDay)
                                        {
                                            // جه بدري ومشي في ميعاده
                                            var attendanceObject = new EmployeeAttendance()
                                            {
                                                empId = excelViewModels[i].empId,
                                                attendanceTime = Convert.ToDateTime(excelViewModels[i].attendanceTime),
                                                departureTime = Convert.ToDateTime(excelViewModels[i].departureTime),
                                                attendaceDay = Convert.ToDateTime(excelViewModels[i].attendaceDay),
                                                extraHours = (float)minusOrAddExtra,
                                                deductHours = 0,
                                                extraAmount=(float) extraAmpunt,
                                                deductAmount=0



                                            };
                                            attendance.Add(attendanceObject);

                                        }
                                        //مشي قبل الوقت
                                        else
                                        {
                                             minus = (float) Math.Abs((emp.requiredDepartureTime.TimeOfDay.TotalHours - Convert.ToDateTime(excelViewModels[i].departureTime).TimeOfDay.TotalHours) * emp.requiredDeductHours);
                                           var DeductAmount =minus* (float)emp.requiredSalaryPerHour;
                                            var attendanceObject = new EmployeeAttendance()
                                            {
                                                empId = excelViewModels[i].empId,
                                                attendanceTime = Convert.ToDateTime(excelViewModels[i].attendanceTime),
                                                departureTime = Convert.ToDateTime(excelViewModels[i].departureTime),
                                                attendaceDay = Convert.ToDateTime(excelViewModels[i].attendaceDay),

                                                deductHours = minus,
                                               extraHours = minusOrAddExtra,
                                               extraAmount = (float) extraAmpunt,
                                               deductAmount= DeductAmount





                                            };
                                            attendance.Add(attendanceObject);

                                        }
                                    }
                                }
                                // مشي في ميعاده
                                else
                                {

                                    //جه بعد الوقت
                                    if (Convert.ToDateTime(excelViewModels[i].attendanceTime).TimeOfDay.TotalHours > emp.requiredAttendanceTime.TimeOfDay.TotalHours)
                                    {
                                       var minusHours = (float)  Math.Abs( Convert.ToDateTime(excelViewModels[i].attendanceTime).TimeOfDay.TotalHours - emp.requiredAttendanceTime.TimeOfDay.TotalHours) * emp.requiredDeductHours;
                                        var minusAmount = minusHours * (float)emp.requiredSalaryPerHour;
                                        // جه بدري ومشي بعد الوقت
                                        var attendanceObject = new EmployeeAttendance()
                                        {
                                            empId = excelViewModels[i].empId,
                                            attendanceTime = Convert.ToDateTime(excelViewModels[i].attendanceTime),
                                            departureTime = Convert.ToDateTime(excelViewModels[i].departureTime),
                                            attendaceDay = Convert.ToDateTime(excelViewModels[i].attendaceDay),
                                            extraHours = 0,
                                            deductHours = minusHours,
                                            deductAmount = minusAmount,
                                            extraAmount=0,




                                        };
                                        attendance.Add(attendanceObject);

                                    }
                                    //جه في الوقت
                                    else if (Convert.ToDateTime(excelViewModels[i].attendanceTime).TimeOfDay.TotalHours == emp.requiredAttendanceTime.TimeOfDay.TotalHours)
                                    {

                                        //  ومشي في معاده
                                        var attendanceObject = new EmployeeAttendance()
                                        {
                                            empId = excelViewModels[i].empId,
                                            attendanceTime = Convert.ToDateTime(excelViewModels[i].attendanceTime),
                                            departureTime = Convert.ToDateTime(excelViewModels[i].departureTime),
                                            attendaceDay = Convert.ToDateTime(excelViewModels[i].attendaceDay),
                                            extraHours = 0,
                                            deductHours=0,
                                            deductAmount = 0,
                                            extraAmount = 0,


                                        };
                                        attendance.Add(attendanceObject);
                                    }
                                    //جه قبل الوقت
                                    else
                                    {
                                        var minusOrAddExtra = (emp.requiredAttendanceTime.TimeOfDay.TotalHours - Convert.ToDateTime(excelViewModels[i].attendanceTime).TimeOfDay.TotalHours) * emp.requiredExtraHours;
                                        var extraAmount = minusOrAddExtra*(float) emp.requiredSalaryPerHour;
                                        var attendanceObject = new EmployeeAttendance()
                                        {
                                            empId = excelViewModels[i].empId,
                                            attendanceTime = Convert.ToDateTime(excelViewModels[i].attendanceTime),
                                            departureTime = Convert.ToDateTime(excelViewModels[i].departureTime),
                                            attendaceDay = Convert.ToDateTime(excelViewModels[i].attendaceDay),

                                            extraHours = (float)minusOrAddExtra,
                                            deductHours = 0,
                                            extraAmount =(float) extraAmount,
                                            deductAmount = 0



                                        };
                                        attendance.Add(attendanceObject);

                                    }

                                }
                            }
                            //جه في ميعاده
                            else
                            {
                                // جه في ميعاده ومشي بدري او متأخر
                                if (emp.requiredDepartureTime.TimeOfDay != Convert.ToDateTime(excelViewModels[i].departureTime).TimeOfDay)
                                {

                                    //  مشي بدري او متأخر 
                                    if (emp.requiredDepartureTime.TimeOfDay != Convert.ToDateTime(excelViewModels[i].departureTime).TimeOfDay)
                                    {
                                        // مشي بعد الوقت
                                        if (Convert.ToDateTime(excelViewModels[i].departureTime).TimeOfDay> emp.requiredDepartureTime.TimeOfDay)
                                        {
                                            // ساعات الزيادة
                                            var minusOrAddExtra = (Convert.ToDateTime(excelViewModels[i].departureTime).TimeOfDay.TotalHours - emp.requiredDepartureTime.TimeOfDay.TotalHours ) * emp.requiredExtraHours;
                                            // كمية الزيادة
                                            var minusOrAddExtraAmount = minusOrAddExtra *(float) emp.requiredSalaryPerHour;
                                            var attendanceObject = new EmployeeAttendance()
                                            {
                                                empId = excelViewModels[i].empId,
                                                attendanceTime = Convert.ToDateTime(excelViewModels[i].attendanceTime),
                                                departureTime = Convert.ToDateTime(excelViewModels[i].departureTime),
                                                attendaceDay = Convert.ToDateTime(excelViewModels[i].attendaceDay),

                                                extraHours = (float)minusOrAddExtra,
                                                deductHours=0,
                                                extraAmount= (float)minusOrAddExtraAmount,
                                                deductAmount= 0,



                                            };
                                            attendance.Add(attendanceObject);

                                        }
                                        // مشي قبل الوقت
                                        else
                                        {
                                            // عدد ساعات الخصم
                                            var minusOrAddDeduct = (  emp.requiredDepartureTime.TimeOfDay.TotalHours - Convert.ToDateTime(excelViewModels[i].departureTime).TimeOfDay.TotalHours) * emp.requiredDeductHours;
                                            var minusOrAddDeductAmount = minusOrAddDeduct *(float) emp.requiredSalaryPerHour;
                                            var attendanceObject = new EmployeeAttendance()
                                            {
                                                empId = excelViewModels[i].empId,
                                                attendanceTime = Convert.ToDateTime(excelViewModels[i].attendanceTime),
                                                departureTime = Convert.ToDateTime(excelViewModels[i].departureTime),
                                                attendaceDay = Convert.ToDateTime(excelViewModels[i].attendaceDay),

                                                deductHours = (float)minusOrAddDeduct,
                                                deductAmount = (float) minusOrAddDeductAmount,
                                                extraHours = 0,
                                                extraAmount= 0



                                            };
                                            attendance.Add(attendanceObject);
                                        }
                                    }
                                    //  مشي في معاده 
                                    else
                                    {
                                        // في حاله جه في معاده ومشي في ميعاده
                                        var attendanceObject = new EmployeeAttendance()
                                        {
                                            empId = excelViewModels[i].empId,
                                            attendanceTime = Convert.ToDateTime(excelViewModels[i].attendanceTime),
                                            departureTime = Convert.ToDateTime(excelViewModels[i].departureTime),
                                            attendaceDay = Convert.ToDateTime(excelViewModels[i].attendaceDay),
                                            extraHours = 0,
                                            deductHours = 0



                                        };
                                        attendance.Add(attendanceObject);

                                    }
                                }
                                else
                                {

                                    // في حاله جه في معاده ومشي في ميعاده
                                    var attendanceObject = new EmployeeAttendance()
                                    {
                                        empId = excelViewModels[i].empId,
                                        attendanceTime = Convert.ToDateTime(excelViewModels[i].attendanceTime),
                                        departureTime = Convert.ToDateTime(excelViewModels[i].departureTime),
                                        attendaceDay = Convert.ToDateTime(excelViewModels[i].attendaceDay),
                                        extraHours = 0,
                                        deductHours = 0,
                                        extraAmount = 0,
                                        deductAmount = 0



                                    };
                                    attendance.Add(attendanceObject);
                                }

                            }

                        }

                    }
                    
                 
                  

                 }
            }
            catch (Exception)
            {

                throw;
            }
             employee=null;
             day="";
             date =null;
            return attendance;
        }

        public IActionResult saveInDataBase()
        {
            if (HttpContext.Session.GetString("attendDisplay") == "True")
            {
                return View();

            }

            return View("ErrorPage");
        }
        [HttpPost]

        public IActionResult saveInDataBase(IFormFile formFile, [FromServices] IWebHostEnvironment hostingEnvironment)
        {
            try
            {
                if (formFile == null)
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
                Employee employeeProblem;
                string dayOfHoliday;
                DateTime? date;
                var attendanceToDatabase = GetAttencanceListToDataBase(attendance,out employeeProblem,out dayOfHoliday, out date);
                // هاكريت هنا فيو باج اقوله فيها عندك يوم اجازة وانت مدخلي موظف
                foreach (var item in attendanceToDatabase)
                {
                    _db.EmployeesAttendance.Add(item);
                }
                _db.SaveChanges();
            }
            catch (Exception)
            {

            }

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
