using Microsoft.AspNetCore.Mvc;
using HR_Sys.Models;
using Microsoft.AspNetCore.Http;
using ExcelDataReader;
using Microsoft.AspNetCore.Mvc.Rendering;
using HR_Sys.ViewModels;
using System.Globalization;

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
      
    private List<EmployeeAttendance> GetAttencanceListToDataBase(List<EmployeeAttendanceExcelViewModel> excelViewModels,out Employee employee,out string day, out  DateTime date,out string typeHoliday ,out List<int>? idsNotExist, out List<int> idsReapeted ,out string exsistInDb, out List<int> idsAllSheet)
        {
            List<EmployeeAttendance> attendance =new List<EmployeeAttendance>();
            List<int> ids =new List<int>();
            try
            {
                for (int i = 0; i < excelViewModels.Count; i++)
                {
                    ids.Add(excelViewModels[i].empId);

                }




                // لو ال id غلط

                var validIds = _db
                   .Employees
                   .Where(obj => ids.Contains(obj.id))
                   .Select(obj => obj.id).ToList();

                List<int> idsThatDoNotExistInTheDb = ids.Except(validIds).ToList();

                if (idsThatDoNotExistInTheDb.Count >0)
                {


                    idsNotExist = idsThatDoNotExistInTheDb;
                    employee = null;
                    day = "";
                    date = new DateTime(1000, 1, 1);
                    typeHoliday = "";
                    idsReapeted = null;
                    exsistInDb = "";
                    idsAllSheet = null;
                    return attendance;
                }

                // id متكرر
                var isRepeated = ids.GroupBy(x => x)
              .Where(g => g.Count() > 1)
              .Select(y => y.Key)
              .ToList();
                if (isRepeated.Count>0)
                {


                    idsNotExist = null;
                    employee = null;
                    day = "";
                    date = new DateTime(1000, 1, 1);
                    typeHoliday = "";
                    idsReapeted = isRepeated;
                    exsistInDb = "";
                    idsAllSheet = null;

                    return attendance;
                }







                var emps = _db.Employees.Where(em => ids.Contains(em.id)).ToList();
                idsAllSheet = ids;


                var Annuals = _db.annualHoliday.ToList();
               

               
                for (int i = 0; i < excelViewModels.Count; i++)
                 {
                    
                    
                    var minusOrAdds1 = 0;
                    float minus = 0;

                    foreach (var emp in emps)
                    {




                        if (emp.id== excelViewModels[i].empId)
                        {

                            foreach (var item in emp.GeneralSettings)
                            {
                                if (item.attendaceDay.Date == Convert.ToDateTime(excelViewModels[i].attendaceDay).Date)
                                {
                                    employee = emp;
                                    day = Convert.ToDateTime(excelViewModels[i].attendaceDay).DayOfWeek.ToString();
                                    date = Convert.ToDateTime(excelViewModels[i].attendaceDay);
                                    exsistInDb = " تم ادخالة من قبل في قاعده البيانات";
                                    idsNotExist = null;
                                    idsReapeted = null;
                                    typeHoliday = "";
                                    idsAllSheet = null;

                                    return attendance;
                                }
                               
                            }

                            // دخل تاريخ قبل تاريخ ابتداء الشركة

                            if (Convert.ToDateTime(excelViewModels[i].attendaceDay).Date <= new DateTime(2008, 1, 1).Date)
                            {
                                employee = emp;
                                day = Convert.ToDateTime(excelViewModels[i].attendaceDay).DayOfWeek.ToString();
                                date = Convert.ToDateTime(excelViewModels[i].attendaceDay);
                                typeHoliday = "تاريخ ابتداء الشركة او قبل ذلك";
                                idsNotExist = null;
                                idsReapeted = null;
                                exsistInDb = "";
                                idsAllSheet = null;

                                return attendance;
                            }


                            // الاجازات السنويه
                            foreach (var itemsAnnuals in Annuals)
                            {
                                if (Convert.ToDateTime(excelViewModels[i].attendaceDay).ToShortDateString() == Convert.ToDateTime(itemsAnnuals.dateHoliday).ToShortDateString())
                                {
                                    employee = emp;
                                    day = Convert.ToDateTime(itemsAnnuals.dateHoliday).DayOfWeek.ToString();
                                    date = Convert.ToDateTime(itemsAnnuals.dateHoliday);
                                    typeHoliday = "سنوية" + "(" + itemsAnnuals.nameHoliday + ")";
                                    idsNotExist = null;
                                    idsReapeted = null;
                                    exsistInDb = "";
                                    idsAllSheet = null;

                                    return attendance;
                                }
                            }

                            // الاجازة الاول 
                            foreach (var item in emp.TypesOfVacationsEmps)
                            {
                               

                                string days = Convert.ToDateTime(excelViewModels[i].attendaceDay).DayOfWeek.ToString();

                                //الاجازة بتاعته
                                if (Convert.ToDateTime(excelViewModels[i].attendaceDay).Date.CompareTo(Convert.ToDateTime(item.date).Date)==0 || (days == item.days.displayNameEnglish && item.vacId==1))
                                {
                                    employee=emp;
                                    day= item.days.daysName;
                                    date=Convert.ToDateTime(item.date).Date;
                                    typeHoliday = item.VacationType.vacationName;
                                    idsNotExist = null;
                                    idsReapeted = null;
                                    exsistInDb = "";
                                    idsAllSheet = null;

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
             date =new DateTime(1000,1,1);
            typeHoliday = "";
            idsNotExist = null;
            idsReapeted = null;
            exsistInDb = "";
            

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
                DateTime date;
                string typeHoliday;
                List<int>? ids=new List<int>();
                List<int> idsOfallSheet = new List<int>();
                List<int> idsRepeated=new List<int>();
                string existInDb = "";

                var attendanceToDatabase = GetAttencanceListToDataBase(attendance,out employeeProblem,out dayOfHoliday, out date,out typeHoliday,out ids,out idsRepeated,out existInDb,out idsOfallSheet);
                // repeated date 
                if (existInDb!="")
                {
                    ViewBag.EmployeeProblem =" الموظف الذي يكون id=(" + employeeProblem.id + ")واسمه("+ employeeProblem.empName+")  تم ادخال يوم حضورة في يوم الموافق (" + dayOfHoliday+")  الموافق ("+ date.ToShortDateString()+ ") "+ existInDb;
                    return View();
                }
                // ids not found
                if (ids != null )
                {
                    string idsString = "";
                    for (int i = 0; i < ids.Count; i++)
                    {
                        idsString += ids[i].ToString() + " , ";
                    }
                    ViewBag.EmployeeProblem = "هذه ال " + "ids: " + idsString + " لا توجد في الداتا بيز";
                    return View();

                }
                if ( idsRepeated!=null  )
                {
                    if (idsRepeated.Count > 0)
                    {


                        string idsString = "";
                        for (int i = 0; i < idsRepeated.Count; i++)
                        {
                            idsString += idsRepeated[i].ToString() + " , ";
                        }
                        ViewBag.EmployeeProblem = "هذه ال " + "ids: " + idsString + " متكرره ";
                        return View();
                    }

                }

                if (employeeProblem!=null&& existInDb=="")
                {
                    ViewBag.EmployeeProblem =" الموظف الذي يكون id=(" + employeeProblem.id + ")واسمه("+ employeeProblem.empName+") يكون اجازة في يوم الموافق (" + dayOfHoliday+")  الموافق ("+ date.ToShortDateString()+ ")ونوع الاجازة ("+ typeHoliday +")";
                    return View();
                }
                else
                {
                    foreach (var item in attendanceToDatabase)
                    {
                        _db.EmployeesAttendance.Add(item);
                    }
                    _db.SaveChanges();
                    ViewBag.EmployeeSuccses = "تم ادخال البيانات بنجاح";

                    addToEmpReport(idsOfallSheet);
                }

            }
            catch (Exception)
            {
                ViewBag.EmployeeProblem = "حدث خطب ما ربما ادخلت بينات غير صحيحه او ربما لم تدخل صيغة ال excel sheet";
            }

            return View();
        }

        private void addToEmpReport(List<int> idsOfallSheet)
        {
            var ListOfEmPReport=new List<EmpReport>();
            var emps = _db.EmployeesAttendance.Where(em => idsOfallSheet.Contains(em.empId) && em.attendaceDay.Month==DateTime.Today.AddMonths(-1).Month && em.attendaceDay.Year== DateTime.Today.Year).ToList();
            var emplyeesDays = _db.Employees.Where(em => idsOfallSheet.Contains(em.id)).ToList();
            var emplyeesReport = _db.EmpReports.Where(em => idsOfallSheet.Contains(em.empId)).ToList();
            int? numAbsenceDays = 0;

            foreach (var item in idsOfallSheet)
            {

                var numAttendanceDays = emps
                    .GroupBy(x => item)
                    .Select(x => x.Count(y => y.empId == item)).FirstOrDefault();
                foreach (var itemDays in emplyeesDays)
                {
                    if (itemDays.id == item)
                    {
                         numAbsenceDays = itemDays.requiredDaysPerMonth - numAttendanceDays;


                    }
                }

                var numOfExtraHours = emps
                    .GroupBy(x => item)
                    .Select(x => x.Sum(y => y.extraHours)).FirstOrDefault();
                var numOfDeductHours = emps
                    .GroupBy(x => item)
                    .Select(x => x.Sum(y => y.deductHours)).FirstOrDefault();


                var totalOfExtraPrice = emps
                     .GroupBy(x => item)
                     .Select(x => x.Sum(y => y.extraAmount)).FirstOrDefault();

                var totalOfDeductionPrice = emps
                   .GroupBy(x => item)
                   .Select(x => x.Sum(y => y.deductAmount)).FirstOrDefault();

                var idmonth = emps.Select(x => x.attendaceDay).FirstOrDefault();
                var empReport = new EmpReport()
                {
                    empId=item,
                    year = DateTime.Now.Year,   
                    idmonth= idmonth.Month,
                    numAttendanceDays = numAttendanceDays,
                    numAbsenceDays= numAbsenceDays,

                    numOfDeductHours= numOfDeductHours,
                    numOfExtraHours= numOfExtraHours,
                    totalOfExtraPrice =totalOfExtraPrice,
                    totalOfDeductionPrice=totalOfDeductionPrice,


                    
                };
                var numContainsThisElemnt = emplyeesReport.Where(em => empReport.idmonth == em.idmonth && empReport.year==em.year).FirstOrDefault();
                if (numContainsThisElemnt !=null)
                {
                    _db.Remove(numContainsThisElemnt);
                    _db.SaveChanges();

                }
                    ListOfEmPReport.Add(empReport);




            }


            _db.EmpReports.AddRange(ListOfEmPReport);
            _db.SaveChanges();

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
                                
                        
                       
                        attendance.Add(new EmployeeAttendanceExcelViewModel()
                        {
                            empId=Convert.ToInt32(id),
                            attendanceTime=attendanceTime,
                            departureTime= departureTime,
                            attendaceDay = DayDate,
                          

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
