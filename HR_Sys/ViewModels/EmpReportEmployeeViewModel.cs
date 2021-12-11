using System.ComponentModel;

namespace HR_Sys.ViewModels
{
    public class EmpReportEmployeeViewModel
    {

        [DisplayName("السنة")]

        public int? year { get; set; }
        public int? numAttendanceDays { get; set; }
        public int? numAbsenceDays { get; set; }
        public float? numOfExtraHours { get; set; }
        public float? numOfDeductHours { get; set; }
        public float? totalOfExtraPrice { get; set; }
        public float? totalOfDeductionPrice { get; set; }
        public float? NonNetSalary { get; set; }
        public float? GrossSalary { get; set; }
        public float? netSalary { get; set; }
 
        public int empId { get; set; }

        public string empName { get; set; }

        public string deptName { get; set; }
        public double? empNetSalary { get; set; }
    }
}
