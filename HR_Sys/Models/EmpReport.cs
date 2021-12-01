using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HR_Sys.Models.BaseIDEntity;

namespace HR_Sys.Models
{
    public class EmpReport : CommonProps
    {
        public string month { get; set; } 
        public int? year { get; set; }    
        public int? numAttendanceDays { get; set; }
        public int? numAbsenceDays { get; set; }
        public float? numOfExtraHours { get; set; }
        public float? numOfDeductHours { get; set; }
        public float? totalOfExtraPrice { get; set; }
        public float? totalOfDeductionPrice { get; set; }
        ////جاااامد
        //public float? gross_salary { get; set; }
        //public float? insurancesSalary { get; set; }
        public float? netSalary { get; set; }


        //relation with employee
        [ForeignKey("Employees")]
        public int empId { get; set; }
        public virtual Employee Employees { get; set; }



    }
}
