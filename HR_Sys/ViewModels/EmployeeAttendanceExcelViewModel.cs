using HR_Sys.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_Sys.ViewModels
{
    public class EmployeeAttendanceExcelViewModel
    {
        public int id { get; set; }
        public string attendanceTime { get; set; }


        public string departureTime { get; set; }
        public string attendaceDay { get; set; }

        public bool? isOff { get; set; }

        //relation with employee
        [ForeignKey("Employee")]
        public int empId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
