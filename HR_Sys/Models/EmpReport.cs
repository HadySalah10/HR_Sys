using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HR_Sys.Models.BaseIDEntity;

namespace HR_Sys.Models
{
    public class EmpReport : CommonProps
    {
        [ForeignKey("Months")]
        public int idmonth { get; set; }

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


        //relation with employee
        [ForeignKey("Employees")]
        public int empId { get; set; }
        public virtual Employee Employees { get; set; }
        public virtual Months Months { get; set; }



    }
}
